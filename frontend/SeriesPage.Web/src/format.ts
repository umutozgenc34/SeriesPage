export function pad(value: number): string {
  return value.toString().padStart(2, '0')
}

export function plural(count: number, singular: string, pluralForm = `${singular}s`): string {
  return `${count} ${count === 1 ? singular : pluralForm}`
}
