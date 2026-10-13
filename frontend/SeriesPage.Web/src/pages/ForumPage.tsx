import { useEffect, useState } from 'react'
import { seriesApi } from '../api/series'
import type { Review } from '../api/types'
import { EmptyState, LoadState } from '../components/LoadState'
import { PageTitle } from '../components/PageTitle'
import { ReviewCard } from '../components/ReviewCard'
import { ReviewForm } from '../components/ReviewForm'
import { plural } from '../format'
import { useApi } from '../hooks/useApi'
import './ForumPage.css'

export function ForumPage() {
  const reviewsRequest = useApi(seriesApi.reviews)
  const [reviews, setReviews] = useState<Review[]>([])

  useEffect(() => {
    if (reviewsRequest.data) setReviews([...reviewsRequest.data].sort((a, b) => b.id - a.id))
  }, [reviewsRequest.data])

  const average = reviews.length > 0 ? reviews.reduce((total, review) => total + review.rating, 0) / reviews.length : null
  const meta = average !== null ? `${plural(reviews.length, 'review')}, average ${average.toFixed(1)}` : undefined

  return (
    <div className="page forum">
      <PageTitle meta={meta}>Forum</PageTitle>
      <div className="forum__layout">
        <section className="forum__reviews" aria-label="Reviews">
          <LoadState
            loading={reviewsRequest.loading}
            error={reviewsRequest.error}
            onRetry={reviewsRequest.reload}
            loadingText="Loading reviews…"
          >
            {reviews.length > 0 ? (
              <ol>
                {reviews.map((review) => (
                  <li key={review.id}>
                    <ReviewCard review={review} />
                  </li>
                ))}
              </ol>
            ) : (
              <EmptyState>
                <p>No one has written a review yet. Use the form to start the conversation.</p>
              </EmptyState>
            )}
          </LoadState>
        </section>
        <aside className="forum__compose">
          <ReviewForm onPosted={(review) => setReviews((current) => [review, ...current])} />
        </aside>
      </div>
    </div>
  )
}
