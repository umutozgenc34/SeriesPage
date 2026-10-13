import type { ReactNode } from 'react'
import type { ApiError } from '../api/client'
import './LoadState.css'

interface LoadStateProps {
  loading: boolean
  error: ApiError | null
  onRetry: () => void
  loadingText: string
  children: ReactNode
}

export function LoadState({ loading, error, onRetry, loadingText, children }: LoadStateProps) {
  if (loading) {
    return (
      <p className="load-state" role="status">
        {loadingText}
      </p>
    )
  }

  if (error) {
    return (
      <div className="load-state load-state--error" role="alert">
        <p>{error.message}</p>
        <button type="button" className="button" onClick={onRetry}>
          Try again
        </button>
      </div>
    )
  }

  return <>{children}</>
}

export function EmptyState({ children }: { children: ReactNode }) {
  return <div className="load-state">{children}</div>
}
