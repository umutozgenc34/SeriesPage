export interface Summary {
  id: number
  text: string
}

export interface Season {
  id: number
  seasonNumber: number
}

export interface Episode {
  id: number
  name: string
  episodeNumber: number
  videoUrl: string
  seasonNumber: number
}

export interface SeasonWithEpisodes extends Season {
  episodes: Episode[]
}

export interface CastMember {
  id: number
  nameInTheSeries: string
  realName: string
  imageUrl: string | null
}

export interface Scene {
  id: number
  description: string | null
  videoUrl: string
}

export interface Photo {
  id: number
  imageUrl: string
}

export interface Award {
  id: number
  name: string
  winnerName: string
  category: string
  year: number
}

export interface Review {
  id: number
  nickName: string
  title: string
  content: string
  rating: number
}

export interface CreateReviewRequest {
  nickName: string
  email: string | null
  title: string
  content: string
  rating: number
}
