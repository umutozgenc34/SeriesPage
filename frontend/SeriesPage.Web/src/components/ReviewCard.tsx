import type { Review } from '../api/types'
import './ReviewCard.css'

export function ReviewCard({ review }: { review: Review }) {
  return (
    <article className="review-card">
      <header className="review-card__header">
        <h3 className="review-card__title">{review.title}</h3>
        <p className="review-card__rating" aria-label={`Rated ${review.rating} out of 10`}>
          {review.rating}
          <span>/10</span>
        </p>
      </header>
      <p className="review-card__content">{review.content}</p>
      <p className="review-card__author">{review.nickName}</p>
    </article>
  )
}
