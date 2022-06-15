import { createRouter, createWebHistory } from 'vue-router'
import type { RouteRecordRaw } from 'vue-router';
import HomeView from '../views/HomeView.vue';
import { LayoutDefault, LayoutTopHeaderContentOnly, LayoutTopHeaderWithSidebar } from '../components/layouts';
import { useNavigationMenu } from '../composables/navmenu.composable.';

import VehicleRoutes from '../modules/vehicles/routes';

const { getRoutes } = useNavigationMenu();


// const baseRoutes: RouteRecordRaw[] = [
//   {
//     path: '/',
//     name: 'home',
//     component: HomeView,
//     meta: { layout: LayoutTopHeaderWithSidebar }
//   },
//   {
//     path: '/about',
//     name: 'about',
//     meta: { layout: LayoutDefault },
//     component: () => import('../views/AboutView.vue')
//   },
//   {
//     path: '/drivers',
//     name: 'drivers',
//     meta: { layout: LayoutDefault },
//     component: () => import('../views/AboutView.vue')
//   },
//   {
//     path: '/data-references',
//     name: 'data-references',
//     meta: { layout: LayoutDefault },
//     component: () => import('../views/AboutView.vue')
//   },
//   {
//     path: '/fleet-operations',
//     name: 'fleet-operations',
//     meta: { layout: LayoutDefault },
//     component: () => import('../views/AboutView.vue')
//   }
// ]

// const routes: RouteRecordRaw[] = baseRoutes.concat(VehicleRoutes);


const routes = getRoutes();


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

// router.afterEach((to, from, failure) => {
//   console.log(to);
// })

export default router
