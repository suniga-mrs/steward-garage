import TestLoading from '../app/test-loading.vue';
import { defineAsyncComponent, defineComponent } from 'vue';

import _LayoutDefault from './layout-default.vue';
import _LayoutTopHeaderContentOnly from './layout-top-header-content-only.vue';
import _LayoutTopHeaderWithSidebar from './layout-top-header-with-sidebar.vue';

// export const layouts = {
//     LayoutDefault: defineAsyncComponent(() => import('./layout-default.vue')),

// }

export const LayoutDefault = _LayoutDefault;
export const LayoutTopHeaderContentOnly = _LayoutTopHeaderContentOnly;
export const LayoutTopHeaderWithSidebar = _LayoutTopHeaderWithSidebar;

// export const LayoutDefault = defineAsyncComponent({
//   loader: () => import('./layout-default.vue'),
//   loadingComponent: TestLoading,
// });

// export const LayoutTopHeaderContentOnly = defineAsyncComponent({
//   loader: () => import('./layout-top-header-content-only.vue'),
//   loadingComponent: TestLoading,
// });
// export const LayoutTopHeaderWithSidebar = defineAsyncComponent({
//   loader: () => import('./layout-top-header-with-sidebar.vue'),
//   loadingComponent: TestLoading,
// });
