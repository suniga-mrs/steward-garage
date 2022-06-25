import _merge from 'lodash.merge';

export function merge<TObj>(_obj: TObj, _src: TObj) {
  return _merge(_obj, _src);
}
