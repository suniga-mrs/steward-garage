import { ref, reactive, type ComputedRef } from 'vue';

export interface ILayoutState {
  classes: Array<string>;
}

const layoutState: ILayoutState = reactive({
  classes: [],
});

export default function useLayout() {
  function addClass(classNames: string): void {
    const _classNames = classNames.toLowerCase().split(' ');
    _classNames.map((className) => {
      const _className = className.toLowerCase();

      if (!layoutState.classes.includes(_className)) {
        layoutState.classes.push(_className);
      }
    });
  }

  function removeClass(classNames: string): void {
    const _classNames = classNames.toLowerCase().split(' ');
    _classNames.map((className) => {
      const _className = className.toLowerCase();

      if (layoutState.classes.includes(_className)) {
        const i = layoutState.classes.indexOf(_className);
        layoutState.classes.splice(i, 1);
      }
    });
  }

  const classes: ComputedRef<string> = computed(() => {
    return layoutState.classes.join(' ');
  });

  return {
    addClass,
    removeClass,
    classes,
  };
}
