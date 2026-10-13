import { useCallback, useEffect, useState } from 'react'
import { ApiError } from '../api/client'

interface ApiState<T> {
  data: T | null
  error: ApiError | null
  loading: boolean
  reload: () => void
}

export function useApi<T>(loader: () => Promise<T>, deps: unknown[] = []): ApiState<T> {
  const [data, setData] = useState<T | null>(null)
  const [error, setError] = useState<ApiError | null>(null)
  const [loading, setLoading] = useState(true)
  const [attempt, setAttempt] = useState(0)

  const reload = useCallback(() => setAttempt((value) => value + 1), [])

  useEffect(() => {
    let active = true
    setLoading(true)
    setError(null)

    loader()
      .then((result) => {
        if (active) setData(result)
      })
      .catch((reason: unknown) => {
        if (!active) return
        setError(reason instanceof ApiError ? reason : new ApiError(0, 'Something went wrong while loading this page.'))
      })
      .finally(() => {
        if (active) setLoading(false)
      })

    return () => {
      active = false
    }
  }, [attempt, ...deps])

  return { data, error, loading, reload }
}
