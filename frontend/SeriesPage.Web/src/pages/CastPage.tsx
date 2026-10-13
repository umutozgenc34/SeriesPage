import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { PageTitle } from '../components/PageTitle'
import { initials, plural } from '../format'
import { useApi } from '../hooks/useApi'
import './CastPage.css'

export function CastPage() {
  const cast = useApi(seriesApi.cast)

  return (
    <div className="page cast">
      <PageTitle meta={cast.data && cast.data.length > 0 ? plural(cast.data.length, 'person', 'people') : undefined}>
        Cast
      </PageTitle>
      <LoadState loading={cast.loading} error={cast.error} onRetry={cast.reload} loadingText="Loading the cast…">
        {cast.data && cast.data.length > 0 ? (
          <ul className="cast__grid">
            {cast.data.map((member) => (
              <li key={member.id} className="cast__member">
                <div className="cast__portrait">
                  {member.imageUrl ? (
                    <img src={member.imageUrl} alt={member.realName} loading="lazy" />
                  ) : (
                    <span aria-hidden="true">{initials(member.nameInTheSeries)}</span>
                  )}
                </div>
                <h2 className="cast__character">{member.nameInTheSeries}</h2>
                <p className="cast__actor">{member.realName}</p>
              </li>
            ))}
          </ul>
        ) : (
          <EmptyState>
            <p>No cast members have been added yet. Add them through the API to see them here.</p>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
