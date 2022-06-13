import type { RouteRecordRaw } from "vue-router";

import { LayoutTopHeaderContentOnly, LayoutTopHeaderWithSidebar } from '../../components/layouts';


const routes: RouteRecordRaw[] = [
    {
        path: '/vehicles',
        name: 'vehicles',
        component: () => import('./views/VehiclesListView.vue'),
        meta: { layout: LayoutTopHeaderContentOnly },

    },
    {
        path: '/vehicle/:plateNo',
        name: 'vehicle',
        meta: { layout: LayoutTopHeaderWithSidebar },
        component: () => import('./views/VehicleMainView.vue'),
        children: [
            {
                path: 'profile',
                name: 'vehicle-profile',
                component: () => import('./views/VehicleProfileView.vue'),
            },
            {
                path: 'gas-logs',
                name: 'vehicle-gas-log',
                component: () => import('./views/VehicleGasLogView.vue'),
            }
        ]
    }
]


export default routes