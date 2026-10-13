import { Route, Routes } from 'react-router-dom'
import { Layout } from './components/Layout'
import { AwardsPage } from './pages/AwardsPage'
import { CastPage } from './pages/CastPage'
import { EpisodeDetailPage } from './pages/EpisodeDetailPage'
import { EpisodesPage } from './pages/EpisodesPage'
import { ForumPage } from './pages/ForumPage'
import { GalleryPage } from './pages/GalleryPage'
import { HomePage } from './pages/HomePage'
import { NotFoundPage } from './pages/NotFoundPage'
import { ScenesPage } from './pages/ScenesPage'
import { StorylinePage } from './pages/StorylinePage'

export function App() {
  return (
    <Routes>
      <Route element={<Layout />}>
        <Route index element={<HomePage />} />
        <Route path="episodes" element={<EpisodesPage />} />
        <Route path="episodes/:id" element={<EpisodeDetailPage />} />
        <Route path="storyline" element={<StorylinePage />} />
        <Route path="cast" element={<CastPage />} />
        <Route path="scenes" element={<ScenesPage />} />
        <Route path="gallery" element={<GalleryPage />} />
        <Route path="awards" element={<AwardsPage />} />
        <Route path="forum" element={<ForumPage />} />
        <Route path="*" element={<NotFoundPage />} />
      </Route>
    </Routes>
  )
}
