import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { useApi } from '../hooks/useApi'
import './StorylinePage.css'

export function StorylinePage() {
  const summaries = useApi(seriesApi.summaries)

  return (
    <div className="page storyline">
      <h1 className="storyline__title">Storyline</h1>
      <LoadState loading={summaries.loading} error={summaries.error} onRetry={summaries.reload} loadingText="Loading the storyline…">
        {summaries.data && summaries.data.length > 0 ? (
          <div className="storyline__body">
            {summaries.data.map((summary) => (
              <p key={summary.id}>{summary.text}</p>
            ))}
          </div>
        ) : (
          <EmptyState>
            <p>The storyline has not been written yet. Add a summary through the API to publish it here.</p>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
