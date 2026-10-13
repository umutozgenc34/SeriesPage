import { Link, useParams } from 'react-router-dom'
import { seriesApi } from '../api/series'
import { EmptyState, LoadState } from '../components/LoadState'
import { useApi } from '../hooks/useApi'
import type { Episode } from '../api/types'
import './EpisodeDetailPage.css'

export function EpisodeDetailPage() {
  const episodeId = Number(useParams().id)
  const seasons = useApi(seriesApi.seasonsWithEpisodes)

  const allEpisodes: Episode[] = seasons.data?.flatMap((season) => season.episodes) ?? []
  const index = allEpisodes.findIndex((episode) => episode.id === episodeId)
  const episode = index >= 0 ? allEpisodes[index] : null
  const previous = index > 0 ? allEpisodes[index - 1] : null
  const next = index >= 0 && index < allEpisodes.length - 1 ? allEpisodes[index + 1] : null

  return (
    <div className="page episode">
      <LoadState loading={seasons.loading} error={seasons.error} onRetry={seasons.reload} loadingText="Loading episode…">
        {episode ? (
          <article>
            <p className="episode__position">
              Season {episode.seasonNumber}, episode {episode.episodeNumber}
            </p>
            <h1 className="episode__title">{episode.name}</h1>

            {episode.videoUrl ? (
              <video className="episode__video" src={episode.videoUrl} controls preload="metadata" />
            ) : (
              <div className="episode__no-video">
                <p>No video has been uploaded for this episode yet.</p>
              </div>
            )}

            <nav className="episode__pager" aria-label="Other episodes">
              {previous ? (
                <Link to={`/episodes/${previous.id}`} className="episode__pager-link">
                  <span>Previous</span>
                  {previous.name}
                </Link>
              ) : (
                <span />
              )}
              {next && (
                <Link to={`/episodes/${next.id}`} className="episode__pager-link episode__pager-link--next">
                  <span>Next</span>
                  {next.name}
                </Link>
              )}
            </nav>
          </article>
        ) : (
          <EmptyState>
            <p>This episode does not exist or was removed.</p>
            <Link to="/episodes" className="text-link">
              Browse all episodes
            </Link>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
