import { useState, type FormEvent } from 'react'
import { ApiError } from '../api/client'
import { seriesApi } from '../api/series'
import type { Review } from '../api/types'
import './ReviewForm.css'

type FieldName = 'nickName' | 'email' | 'title' | 'content' | 'rating'
type FieldErrors = Partial<Record<FieldName, string>>

interface FormValues {
  nickName: string
  email: string
  title: string
  content: string
  rating: number | null
}

const emptyValues: FormValues = { nickName: '', email: '', title: '', content: '', rating: null }
const ratings = Array.from({ length: 10 }, (_, index) => index + 1)
const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/

function validate(values: FormValues): FieldErrors {
  const errors: FieldErrors = {}
  if (!values.nickName.trim()) errors.nickName = 'Enter a nickname.'
  else if (values.nickName.trim().length > 50) errors.nickName = 'Keep the nickname under 50 characters.'
  if (values.email.trim() && !emailPattern.test(values.email.trim())) errors.email = 'Enter a valid email address or leave it empty.'
  if (!values.title.trim()) errors.title = 'Give your review a title.'
  else if (values.title.trim().length > 255) errors.title = 'Keep the title under 255 characters.'
  if (!values.content.trim()) errors.content = 'Write a few words about the series.'
  else if (values.content.trim().length > 3000) errors.content = 'Keep the review under 3000 characters.'
  if (values.rating === null) errors.rating = 'Pick a rating from 1 to 10.'
  return errors
}

function mapServerErrors(error: ApiError): FieldErrors {
  const errors: FieldErrors = {}
  for (const [key, messages] of Object.entries(error.fieldErrors)) {
    const field = (key.charAt(0).toLowerCase() + key.slice(1)) as FieldName
    if (messages[0]) errors[field] = messages[0]
  }
  return errors
}

interface ReviewFormProps {
  onPosted: (review: Review) => void
}

export function ReviewForm({ onPosted }: ReviewFormProps) {
  const [values, setValues] = useState<FormValues>(emptyValues)
  const [errors, setErrors] = useState<FieldErrors>({})
  const [submitting, setSubmitting] = useState(false)
  const [status, setStatus] = useState<{ kind: 'success' | 'error'; text: string } | null>(null)

  const update = <K extends keyof FormValues>(field: K, value: FormValues[K]) => {
    setValues((current) => ({ ...current, [field]: value }))
    setErrors((current) => ({ ...current, [field]: undefined }))
  }

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setStatus(null)

    const clientErrors = validate(values)
    if (Object.keys(clientErrors).length > 0) {
      setErrors(clientErrors)
      return
    }

    setSubmitting(true)
    try {
      const review = await seriesApi.createReview({
        nickName: values.nickName.trim(),
        email: values.email.trim() || null,
        title: values.title.trim(),
        content: values.content.trim(),
        rating: values.rating ?? 0
      })
      onPosted(review)
      setValues(emptyValues)
      setErrors({})
      setStatus({ kind: 'success', text: 'Review posted.' })
    } catch (reason) {
      const apiError = reason instanceof ApiError ? reason : new ApiError(0, 'The review could not be posted. Try again.')
      setErrors(mapServerErrors(apiError))
      setStatus({ kind: 'error', text: apiError.message })
    } finally {
      setSubmitting(false)
    }
  }

  const fieldError = (field: FieldName) =>
    errors[field] ? (
      <span className="review-form__error" id={`${field}-error`}>
        {errors[field]}
      </span>
    ) : null

  const describedBy = (field: FieldName) => (errors[field] ? `${field}-error` : undefined)

  return (
    <form className="legal-pad review-form" onSubmit={handleSubmit} noValidate>
      <h2 className="review-form__heading">Write a review</h2>

      <label className="review-form__field">
        <span className="review-form__label">Nickname</span>
        <input
          className="review-form__input"
          value={values.nickName}
          onChange={(event) => update('nickName', event.target.value)}
          aria-invalid={Boolean(errors.nickName)}
          aria-describedby={describedBy('nickName')}
          autoComplete="nickname"
          maxLength={50}
        />
        {fieldError('nickName')}
      </label>

      <label className="review-form__field">
        <span className="review-form__label">Email, optional and never shown</span>
        <input
          className="review-form__input"
          type="email"
          value={values.email}
          onChange={(event) => update('email', event.target.value)}
          aria-invalid={Boolean(errors.email)}
          aria-describedby={describedBy('email')}
          autoComplete="email"
        />
        {fieldError('email')}
      </label>

      <label className="review-form__field">
        <span className="review-form__label">Title</span>
        <input
          className="review-form__input"
          value={values.title}
          onChange={(event) => update('title', event.target.value)}
          aria-invalid={Boolean(errors.title)}
          aria-describedby={describedBy('title')}
          maxLength={255}
        />
        {fieldError('title')}
      </label>

      <fieldset className="review-form__field review-form__rating" aria-describedby={describedBy('rating')}>
        <legend className="review-form__label">Rating</legend>
        <div className="review-form__rating-options">
          {ratings.map((rating) => (
            <label key={rating} className="review-form__rating-option">
              <input
                type="radio"
                name="rating"
                value={rating}
                checked={values.rating === rating}
                onChange={() => update('rating', rating)}
              />
              <span>{rating}</span>
            </label>
          ))}
        </div>
        {fieldError('rating')}
      </fieldset>

      <label className="review-form__field">
        <span className="review-form__label">Review</span>
        <textarea
          className="review-form__input review-form__textarea"
          rows={6}
          value={values.content}
          onChange={(event) => update('content', event.target.value)}
          aria-invalid={Boolean(errors.content)}
          aria-describedby={describedBy('content')}
          maxLength={3000}
        />
        {fieldError('content')}
      </label>

      <div className="review-form__actions">
        <button type="submit" className="review-form__submit" disabled={submitting}>
          {submitting ? 'Posting…' : 'Post review'}
        </button>
        {status && (
          <p className={`review-form__status review-form__status--${status.kind}`} role="status">
            {status.text}
          </p>
        )}
      </div>
    </form>
  )
}
