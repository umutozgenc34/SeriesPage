import { get, postJson } from './client'
import type {
  Award,
  CastMember,
  CreateReviewRequest,
  Episode,
  Photo,
  Review,
  Scene,
  SeasonWithEpisodes,
  Summary
} from './types'

export const seriesApi = {
  summaries: () => get<Summary[]>('/api/Summary'),
  seasonsWithEpisodes: () => get<SeasonWithEpisodes[]>('/api/Seasons/with-episodes'),
  episode: (id: number) => get<Episode>(`/api/Episodes/${id}`),
  cast: () => get<CastMember[]>('/api/Casts'),
  scenes: () => get<Scene[]>('/api/Scenes'),
  photos: () => get<Photo[]>('/api/Photos'),
  awards: () => get<Award[]>('/api/Awards'),
  reviews: () => get<Review[]>('/api/Reviews'),
  createReview: (payload: CreateReviewRequest) => postJson<Review>('/api/Reviews', payload)
}
