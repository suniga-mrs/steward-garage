import type { Ref, InjectionKey } from 'vue';

export interface ILayoutStateMethods {
    addClass(classNames: string): void,
    removeClass(classNames: string): void,
}
