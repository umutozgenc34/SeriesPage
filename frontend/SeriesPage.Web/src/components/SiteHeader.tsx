import { NavLink, Link } from 'react-router-dom'
import { seriesTitle } from '../config'
import { navigation } from '../navigation'
import './SiteHeader.css'

export function SiteHeader() {
  return (
    <header className="site-header">
      <div className="page site-header__inner">
        <Link to="/" className="site-header__title">
          {seriesTitle}
        </Link>
        <nav aria-label="Main">
          <ul className="site-header__nav">
            {navigation.map((item) => (
              <li key={item.to}>
                <NavLink to={item.to} className="site-header__link">
                  {item.label}
                </NavLink>
              </li>
            ))}
          </ul>
        </nav>
      </div>
    </header>
  )
}
