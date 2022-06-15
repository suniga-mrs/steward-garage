import type { INavigationItem, TNavigationItem } from '../ts/navigation';
import { LayoutTopHeaderContentOnly, LayoutTopHeaderWithSidebar } from '../components/layouts';
import { defineAsyncComponent } from 'vue';

const NavigationMenu: TNavigationItem[] = [
    {
        name: 'dashboard',
        title: "Dashboard",
        route: '/dashboard',
        view: () => import('../views/HomeView.vue'),
        layout: LayoutTopHeaderContentOnly
    },
    // {
    //     name: 'vehicles',
    //     route: '/vehicles',
    //     title: "Vehicles",
    //     layout: LayoutTopHeaderWithSidebar,
    //     view: () => import('../modules/vehicles/views/VehiclesListView.vue'),

    // },
    // {
    //     route: '/vehicle/:plateNo',
    //     title: "Vehicle Profile",
    //     name: 'vehicle',
    //     layout: LayoutTopHeaderWithSidebar,
    //     view: () => import('../modules/vehicles/views/VehicleMainView.vue'),
    //     children: [
    //         {
    //             name: 'gas-logs',
    //             route: '/gas-logs',
    //             title: 'Gas Logs',
    //             view: () => import('../views/AboutView.vue'),
    //         }, {
    //             name: 'maintenance-logs',
    //             route: '/maintenance-logs',
    //             title: 'Maintenance Logs',
    //             view: () => import('../views/AboutView.vue'),
    //         }, {
    //             name: 'odometer-logs',
    //             route: '/odometer-logs',
    //             title: 'Odometer Logs',
    //             view: () => import('../views/AboutView.vue'),
    //         }, {
    //             name: 'trip-logs',
    //             route: '/trip-logs',
    //             title: 'Trip Logs',
    //             view: () => import('../views/AboutView.vue'),
    //         }, {
    //             name: 'incident-logs',
    //             route: '/incident-report',
    //             title: 'Incident Reports',
    //             view: () => import('../views/AboutView.vue'),
    //         }
    //     ]
    // },

    // {
    //     name: 'drivers',
    //     route: '/drivers',
    //     title: "Drivers",
    //     children: [

    //     ]
    // },
    // {
    //     name: 'data-references',
    //     route: '/references',
    //     title: "References",
    //     children: [

    //     ]
    // },
    // {
    //     name: 'fleet-operations',
    //     route: '/fleet-operations',
    //     title: "Fleet Operations",
    //     children: [

    //     ]
    // },
];

export default NavigationMenu;