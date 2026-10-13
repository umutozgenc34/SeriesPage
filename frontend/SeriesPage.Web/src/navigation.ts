export interface NavigationItem {
  to: string
  label: string
}

export const navigation: NavigationItem[] = [
  { to: '/episodes', label: 'Episodes' },
  { to: '/storyline', label: 'Storyline' }
]
