import type { ReactNode } from 'react'
import './PageTitle.css'

interface PageTitleProps {
  children: ReactNode
  meta?: ReactNode
}

export function PageTitle({ children, meta }: PageTitleProps) {
  return (
    <header className="page-title">
      <h1 className="page-title__heading">{children}</h1>
      {meta && <p className="page-title__meta">{meta}</p>}
    </header>
  )
}
