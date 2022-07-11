import TestLoading from '../app/test-loading.vue';

import { defineAsyncComponent } from 'vue';

// export const layouts = {
//     LayoutDefault: defineAsyncComponent(() => import('./layout-default.vue')),

// }

export const LayoutDefault = defineAsyncComponent({
  loader: () => import('./layout-default.vue'),
  loadingComponent: TestLoading,
});

export const LayoutTopHeaderContentOnly = defineAsyncComponent({
  loader: () => import('./layout-top-header-content-only.vue'),
  loadingComponent: TestLoading,
});
export const LayoutTopHeaderWithSidebar = defineAsyncComponent({
  loader: () => import('./layout-top-header-with-sidebar.vue'),
  loadingComponent: TestLoading,
});
