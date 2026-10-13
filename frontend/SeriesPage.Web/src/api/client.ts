const baseUrl = (import.meta.env.VITE_API_BASE_URL ?? '').replace(/\/$/, '')

interface ServiceResponse<T> {
  data?: T
  message?: string
}

interface ValidationProblem {
  title?: string
  message?: string
  errors?: Record<string, string[]>
}

export class ApiError extends Error {
  readonly status: number
  readonly fieldErrors: Record<string, string[]>

  constructor(status: number, message: string, fieldErrors: Record<string, string[]> = {}) {
    super(message)
    this.name = 'ApiError'
    this.status = status
    this.fieldErrors = fieldErrors
  }
}

async function readBody(response: Response): Promise<unknown> {
  const text = await response.text()
  if (!text) return null
  try {
    return JSON.parse(text)
  } catch {
    return null
  }
}

async function request<T>(path: string, init?: RequestInit): Promise<T> {
  let response: Response

  try {
    response = await fetch(`${baseUrl}${path}`, {
      ...init,
      headers: { Accept: 'application/json', ...init?.headers }
    })
  } catch {
    throw new ApiError(0, 'The server could not be reached. Check that the API is running.')
  }

  const body = await readBody(response)

  if (!response.ok) {
    const problem = (body ?? {}) as ValidationProblem
    const fieldErrors = problem.errors ?? {}
    const firstFieldError = Object.values(fieldErrors)[0]?.[0]
    const message = firstFieldError ?? problem.message ?? problem.title ?? `Request failed with status ${response.status}.`
    throw new ApiError(response.status, message, fieldErrors)
  }

  return ((body as ServiceResponse<T> | null)?.data ?? null) as T
}

export function get<T>(path: string): Promise<T> {
  return request<T>(path)
}

export function postJson<T>(path: string, payload: unknown): Promise<T> {
  return request<T>(path, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(payload)
  })
}
