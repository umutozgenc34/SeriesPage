import { Link } from 'react-router-dom'

export function NotFoundPage() {
  return (
    <div className="page" style={{ paddingTop: 'var(--space-6)' }}>
      <h1 className="section-title">Page not found</h1>
      <p style={{ marginTop: 'var(--space-3)', color: 'var(--color-stone)' }}>
        The address may be mistyped, or the page was moved.
      </p>
      <p style={{ marginTop: 'var(--space-4)' }}>
        <Link to="/" className="text-link">
          Go to the home page
        </Link>
      </p>
    </div>
  )
}
