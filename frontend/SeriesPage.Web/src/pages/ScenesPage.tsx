import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { PageTitle } from '../components/PageTitle'
import { plural } from '../format'
import { useApi } from '../hooks/useApi'
import './ScenesPage.css'

export function ScenesPage() {
  const scenes = useApi(seriesApi.scenes)

  return (
    <div className="page scenes">
      <PageTitle meta={scenes.data && scenes.data.length > 0 ? plural(scenes.data.length, 'scene') : undefined}>
        Scenes
      </PageTitle>
      <LoadState loading={scenes.loading} error={scenes.error} onRetry={scenes.reload} loadingText="Loading scenes…">
        {scenes.data && scenes.data.length > 0 ? (
          <ul className="scenes__list">
            {scenes.data.map((scene) => (
              <li key={scene.id} className="scenes__item">
                <video className="scenes__video" src={scene.videoUrl} controls preload="metadata" />
                {scene.description && <p className="scenes__description">{scene.description}</p>}
              </li>
            ))}
          </ul>
        ) : (
          <EmptyState>
            <p>No scenes have been uploaded yet. Upload a clip through the API to add the first one.</p>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
