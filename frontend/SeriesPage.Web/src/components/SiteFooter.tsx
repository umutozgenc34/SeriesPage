import { seriesTitle } from '../config'
import './SiteFooter.css'

export function SiteFooter() {
  return (
    <footer className="site-footer">
      <div className="page site-footer__inner">
        <p>{seriesTitle} fan archive. Unofficial and not affiliated with the network or studio.</p>
        <a href="#top" className="site-footer__top">
          Back to top
        </a>
      </div>
    </footer>
  )
}
