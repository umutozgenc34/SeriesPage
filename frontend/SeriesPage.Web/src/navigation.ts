export interface NavigationItem {
  to: string
  label: string
}

export const navigation: NavigationItem[] = [
  { to: '/episodes', label: 'Episodes' },
  { to: '/storyline', label: 'Storyline' },
  { to: '/cast', label: 'Cast' },
  { to: '/scenes', label: 'Scenes' },
  { to: '/gallery', label: 'Gallery' },
  { to: '/awards', label: 'Awards' }
]
