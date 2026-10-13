import { seriesApi } from '../api/series'
import type { Award } from '../api/types'
import { EmptyState, LoadState } from '../components/LoadState'
import { PageTitle } from '../components/PageTitle'
import { plural } from '../format'
import { useApi } from '../hooks/useApi'
import './AwardsPage.css'

function groupByYear(awards: Award[]): [number, Award[]][] {
  const groups = new Map<number, Award[]>()
  for (const award of awards) {
    groups.set(award.year, [...(groups.get(award.year) ?? []), award])
  }
  return [...groups.entries()].sort(([a], [b]) => b - a)
}

export function AwardsPage() {
  const awards = useApi(seriesApi.awards)

  return (
    <div className="page awards">
      <PageTitle meta={awards.data && awards.data.length > 0 ? plural(awards.data.length, 'award') : undefined}>
        Awards
      </PageTitle>
      <LoadState loading={awards.loading} error={awards.error} onRetry={awards.reload} loadingText="Loading awards…">
        {awards.data && awards.data.length > 0 ? (
          <div className="awards__years">
            {groupByYear(awards.data).map(([year, items]) => (
              <section key={year} className="awards__year" aria-labelledby={`year-${year}`}>
                <h2 id={`year-${year}`} className="awards__year-number">
                  {year}
                </h2>
                <ul className="awards__list">
                  {items.map((award) => (
                    <li key={award.id} className="awards__item">
                      <p className="awards__name">{award.name}</p>
                      <p className="awards__category">{award.category}</p>
                      <p className="awards__winner">{award.winnerName}</p>
                    </li>
                  ))}
                </ul>
              </section>
            ))}
          </div>
        ) : (
          <EmptyState>
            <p>No awards have been added yet. Add them through the API to list them here.</p>
          </EmptyState>
        )}
      </LoadState>
    </div>
  )
}
