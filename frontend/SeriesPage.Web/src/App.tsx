import { Route, Routes } from 'react-router-dom'
import { Layout } from './components/Layout'
import { EpisodeDetailPage } from './pages/EpisodeDetailPage'
import { EpisodesPage } from './pages/EpisodesPage'
import { HomePage } from './pages/HomePage'
import { NotFoundPage } from './pages/NotFoundPage'
import { StorylinePage } from './pages/StorylinePage'

export function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<HomePage />} />
        <Route path="episodes" element={<EpisodesPage />} />
        <Route path="episodes/:id" element={<EpisodeDetailPage />} />
        <Route path="storyline" element={<StorylinePage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Route>
    </Routes>
  )
}
