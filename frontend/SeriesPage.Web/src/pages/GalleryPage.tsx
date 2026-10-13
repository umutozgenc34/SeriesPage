import { useEffect, useRef, useState } from 'react'
import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { PageTitle } from '../components/PageTitle'
import { plural } from '../format'
import { useApi } from '../hooks/useApi'
import './GalleryPage.css'

export function GalleryPage() {
  const photos = useApi(seriesApi.photos)
  const [openIndex, setOpenIndex] = useState<number | null>(null)
  const dialogRef = useRef<HTMLDialogElement>(null)
  const items = photos.data ?? []

  useEffect(() => {
    const dialog = dialogRef.current
    if (!dialog) return
    if (openIndex !== null && !dialog.open) dialog.showModal()
    if (openIndex === null && dialog.open) dialog.close()
  }, [openIndex])

  const step = (direction: number) => {
    setOpenIndex((current) => (current === null ? null : (current + direction + items.length) % items.length))
  }

  const handleKeyDown = (event: React.KeyboardEvent<HTMLDialogElement>) => {
    if (event.key === 'ArrowRight') step(1)
    if (event.key === 'ArrowLeft') step(-1)
  }

  const current = openIndex !== null ? items[openIndex] : null

  return (
    <div className="page gallery">
      <PageTitle meta={items.length > 0 ? plural(items.length, 'photo') : undefined}>Gallery</PageTitle>
      <LoadState loading={photos.loading} error={photos.error} onRetry={photos.reload} loadingText="Loading photos…">
        {items.length > 0 ? (
          <ul className="gallery__grid">
            {items.map((photo, index) => (
              <li key={photo.id}>
                <button type="button" className="gallery__thumb" onClick={() => setOpenIndex(index)}>
                  <img src={photo.imageUrl} alt={`Photo ${index + 1}`} loading="lazy" />
                </button>
              </li>
            ))}
          </ul>
        ) : (
          <EmptyState>
            <p>The gallery is empty. Upload photos through the API to fill it.</p>
          </EmptyState>
        )}
      </LoadState>

      <dialog
        ref={dialogRef}
        className="gallery__dialog"
        aria-label="Photo viewer"
        onClose={() => setOpenIndex(null)}
        onKeyDown={handleKeyDown}
        onClick={(event) => {
          if (event.target === event.currentTarget) setOpenIndex(null)
        }}
      >
        {current && openIndex !== null && (
          <figure className="gallery__figure">
            <img src={current.imageUrl} alt={`Photo ${openIndex + 1}`} />
            <figcaption className="gallery__controls">
              <button type="button" className="button" onClick={() => step(-1)} disabled={items.length < 2}>
                Previous
              </button>
              <span>
                {openIndex + 1} of {items.length}
              </span>
              <button type="button" className="button" onClick={() => step(1)} disabled={items.length < 2}>
                Next
              </button>
              <button type="button" className="button gallery__close" onClick={() => setOpenIndex(null)}>
                Close
              </button>
            </figcaption>
          </figure>
        )}
      </dialog>
    </div>
  )
}
