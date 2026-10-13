import { Link, useSearchParams } from 'react-router-dom'
import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { pad, plural } from '../format'
import { useApi } from '../hooks/useApi'
import './EpisodesPage.css'

export function EpisodesPage() {
  const seasons = useApi(seriesApi.seasonsWithEpisodes)
  const [searchParams, setSearchParams] = useSearchParams()
  const selectedSeason = Number(searchParams.get('season')) || null

  const visibleSeasons = (seasons.data ?? []).filter(
    (season) => selectedSeason === null || season.seasonNumber === selectedSeason
  )

  const selectSeason = (seasonNumber: number | null) => {
    setSearchParams(seasonNumber === null ? {} : { season: seasonNumber.toString() }, { replace: true })
  }

  return (
    <div className="page episodes">
      <h1 className="episodes__title">Episodes</h1>

      <LoadState loading={seasons.loading} error={seasons.error} onRetry={seasons.reload} loadingText="Loading episodes…">
        {seasons.data && seasons.data.length > 0 ? (
          <>
            <div className="episodes__filter" role="group" aria-label="Filter by season">
              <button
                type="button"
                className="episodes__filter-button"
                aria-pressed={selectedSeason === null}
                onClick={() => selectSeason(null)}
              >
                All
              </button>
              {seasons.data.map((season) => (
                <button
                  type="button"
                  key={season.id}
                  className="episodes__filter-button"
                  aria-pressed={selectedSeason === season.seasonNumber}
                  aria-label={`Season ${season.seasonNumber}`}
                  onClick={() => selectSeason(season.seasonNumber)}
                >
                  {season.seasonNumber}
                </button>
              ))}
            </div>

            {visibleSeasons.map((season) => (
              <section key={season.id} className="episodes__season" aria-labelledby={`season-${season.id}`}>
                <h2 id={`season-${season.id}`} className="episodes__season-title">
                  Season {season.seasonNumber}
                  <span>{plural(season.episodes.length, 'episode')}</span>
                </h2>
                {season.episodes.length > 0 ? (
                  <ol className="episodes__list">
                    {season.episodes.map((episode) => (
                      <li key={episode.id}>
                        <Link to={`/episodes/${episode.id}`} className="episodes__row">
                          <span className="episodes__number">{pad(episode.episodeNumber)}</span>
                          <span className="episodes__name">{episode.name}</span>
                          <span className="episodes__status">{episode.videoUrl ? 'Watch' : 'No video yet'}</span>
                        </Link>
                      </li>
                    ))}
                  </ol>
                ) : (
                  <p className="episodes__none">No episodes in this season yet.</p>
                )}
              </section>
            ))}

            {visibleSeasons.length === 0 && (
              <EmptyState>
                <p>There is no season {selectedSeason}.</p>
                <button type="button" className="button" onClick={() => selectSeason(null)}>
                  Show all seasons
                </button>
              </EmptyState>
            )}
          </>
        ) : (
          <EmptyState>
            <p>No episodes have been added yet. Create a season and its episodes through the API to see them here.</p>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
