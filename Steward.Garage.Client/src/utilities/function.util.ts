import _merge from 'lodash.merge';
import { cloneDeep as _cloneDeep } from 'lodash';

export function merge(_obj: any, ..._src: any) {
  return _merge(_obj, ..._src);
}

export function cloneDeep(_src: any) {
  return _cloneDeep(_src);
}


export function isChromium() {
  return Boolean(window.chrome)
}
