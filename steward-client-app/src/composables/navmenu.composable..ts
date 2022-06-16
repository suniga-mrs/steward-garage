import { ref, reactive, type Ref, type ComputedRef } from 'vue';
import type { RouteRecordRaw } from 'vue-router';
import NavMenuData from '../data/navigation-menu';
import type { INavigationItem, TNavigationItem, INavigationItemChildView } from '../ts/navigation';

const currentNavMenuItem: Ref<TNavigationItem | null> = ref(null);
const currParentNavMenuItem: Ref<TNavigationItem | null> = ref(null);

export function useNavigationMenu() {

    let mainMenu: { [key: string]: TNavigationItem; } = {};
    for (let item of NavMenuData) {
        mainMenu[item.name] = item;
    }

    const currChildrenNavMenu = computed(() => currParentNavMenuItem.value?.children || []);

    function getRoutes(): RouteRecordRaw[] {

        const routes: RouteRecordRaw[] = NavMenuData.map(item => {

            const childrenRoutes: RouteRecordRaw[] = [];



            if (item.children) {
                item.children.map(childRoute => {
                    childrenRoutes.push(mapToRouterObj(childRoute));

                });
            }

            const routeItem = mapToRouterObj(item, childrenRoutes);
            return routeItem;

        })

        // console.log(routes);

        return routes
    }

    function mapToRouterObj(item: TNavigationItem, childrenRoutes: RouteRecordRaw[] | undefined = undefined) {
        const routeItem: RouteRecordRaw = {
            name: item.name,
            path: item.route,
            component: item.view,
            redirect: item.redirect,
            meta: { layout: item.layout },
            children: childrenRoutes
        }
        return routeItem;
    }

    function getRouteByPlacement(placement: string): TNavigationItem[] {
        const routes: TNavigationItem[] =
            NavMenuData.filter(item => item.placement?.includes(placement))
        // .map(item => {
        //     const childrenRoutes: RouteRecordRaw[] = [];
        //     const routeItem = mapToRouterObj(item, childrenRoutes);
        //     return routeItem;
        // })

        // console.log(routes);

        return routes
    }

    function setCurrentParentNavMenu(mainMenuRouteName: string) {
        if (mainMenu.hasOwnProperty(mainMenuRouteName)) {
            currParentNavMenuItem.value = mainMenu[mainMenuRouteName];
        }
    }

    return {
        currentNavMenuItem,
        currParentNavMenuItem,
        currChildrenNavMenu,
        getRoutes,
        getRouteByPlacement,
        setCurrentParentNavMenu,
    }

}
