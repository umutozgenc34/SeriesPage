import { Link } from 'react-router-dom'
import { seriesApi } from '../api/series'
import { LoadState } from '../components/LoadState'
import { seriesTitle } from '../config'
import { plural } from '../format'
import { useApi } from '../hooks/useApi'
import './HomePage.css'

export function HomePage() {
  const seasons = useApi(seriesApi.seasonsWithEpisodes)
  const summaries = useApi(seriesApi.summaries)

  const episodeCount = seasons.data?.reduce((total, season) => total + season.episodes.length, 0) ?? 0
  const introduction = summaries.data?.[0]?.text

  return (
    <div className="home">
      <section className="page home__hero" aria-labelledby="home-title">
        <h1 id="home-title" className="home__title">
          {seriesTitle.split(' ').map((word, index) => (
            <span className="home__title-word" key={`${word}-${index}`}>
              <span style={{ animationDelay: `${index * 120}ms` }}>{word}</span>
            </span>
          ))}
        </h1>
        <div className="home__meta">
          {seasons.data && seasons.data.length > 0 && (
            <p className="home__facts">
              {plural(seasons.data.length, 'season')}, {plural(episodeCount, 'episode')}
            </p>
          )}
          {introduction && (
            <div className="home__intro">
              <p>{introduction}</p>
              <Link to="/storyline" className="text-link">
                Read the full storyline
              </Link>
            </div>
          )}
        </div>
      </section>

      <section className="page home__seasons" aria-labelledby="seasons-title">
        <h2 id="seasons-title" className="section-title">
          Seasons
        </h2>
        <LoadState
          loading={seasons.loading}
          error={seasons.error}
          onRetry={seasons.reload}
          loadingText="Loading seasons…"
        >
          {seasons.data && seasons.data.length > 0 ? (
            <ol className="home__season-list">
              {seasons.data.map((season) => (
                <li key={season.id}>
                  <Link to={`/episodes?season=${season.seasonNumber}`} className="home__season">
                    <span className="home__season-number">{season.seasonNumber}</span>
                    <span className="home__season-count">{plural(season.episodes.length, 'episode')}</span>
                  </Link>
                </li>
              ))}
            </ol>
          ) : (
            <p className="home__empty">No seasons have been added yet. Add them through the API to fill this page.</p>
          )}
        </LoadState>
      </section>
    </div>
  )
}
