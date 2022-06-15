import { ref, reactive, type Ref, type ComputedRef } from 'vue';
import type { RouteRecordRaw } from 'vue-router';
import NavMenuData from '../data/navigation-menu';
import type { INavigationItem, TNavigationItem, INavigationItemChildView } from '../ts/navigation';

const currentNavMenuItem: Ref<TNavigationItem | null> = ref(null);

export function useNavigationMenu() {

    const mainMenu = computed(() => NavMenuData);
    const subMenu = computed(() => currentNavMenuItem.value?.children || []);

    function getRoutes(): RouteRecordRaw[] {

        const routes: RouteRecordRaw[] = NavMenuData.map(item => {

            const childrenRoutes: RouteRecordRaw[] = [];

            if (item.children != null) {
                item.children.map(childRoute => {
                    return {
                        name: childRoute.name,
                        path: childRoute.route,
                        component: childRoute.view
                    }
                });
            }
            if (item.view != null) {
                const routeItem: RouteRecordRaw = {
                    name: item.name,
                    path: item.route,
                    component: item.view,
                    meta: { layout: item.layout },
                    children: childrenRoutes
                }
                return routeItem;
            }
            else {
                const routeItem: RouteRecordRaw = {
                    name: item.name,
                    path: item.route,
                    redirect: item.redirect,
                    children: childrenRoutes
                }
                return routeItem;
            }

        })

        return routes
    }

    return {
        mainMenu, subMenu,
        getRoutes,
        setCurrentNavMenu(mainMenuItem: TNavigationItem) {
            currentNavMenuItem.value = mainMenuItem;
        },
    }

}
