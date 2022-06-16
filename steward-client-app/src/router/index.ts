import { createRouter, createWebHistory } from 'vue-router'
import { useNavigationMenu } from '../composables/navmenu.composable.';

import VehicleRoutes from '../modules/vehicles/routes';

const { getRoutes } = useNavigationMenu();

const routes = getRoutes();


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes
})

// router.afterEach((to, from, failure) => {
//   console.log(to);
// })

export default router
