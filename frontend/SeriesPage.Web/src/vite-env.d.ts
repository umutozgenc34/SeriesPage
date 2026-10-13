interface ImportMetaEnv {
  readonly VITE_SERIES_TITLE?: string
  readonly VITE_API_BASE_URL?: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
