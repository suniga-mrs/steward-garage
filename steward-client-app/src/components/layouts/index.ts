
import { defineAsyncComponent } from 'vue'


export const LayoutDefault = defineAsyncComponent(() => import('./layout-default.vue'));
export const LayoutTopHeaderContentOnly = defineAsyncComponent(() => import('./layout-top-header-content-only.vue'));
export const LayoutTopHeaderWithSidebar = defineAsyncComponent(() => import('./layout-top-header-with-sidebar.vue'));
