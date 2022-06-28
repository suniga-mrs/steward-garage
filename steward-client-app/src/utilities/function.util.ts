import _merge from 'lodash.merge';

export function merge(_obj: any, ..._src: any) {
  return _merge(_obj, ..._src);
}

export function isChromium() {
  return Boolean(window.chrome)
}
