import type { INavigationItem, TNavigationItem } from '../ts/navigation';
import { LayoutTopHeaderContentOnly, LayoutTopHeaderWithSidebar } from '../components/layouts';
import { defineAsyncComponent } from 'vue';
import SignInPageVue from '../pages/SignInPage.vue';

const NavigationMenu: TNavigationItem[] = [
    {
        route: '/',
        name: 'landing',
        title: 'Sign In',
        placement: [],
        view: SignInPageVue,
    },
    {
        name: 'dashboard',
        title: 'Dashboard',
        route: '/dashboard',
        placement: ['topbar'],
        layout: LayoutTopHeaderContentOnly,
        view: () => import('../modules/dashboard/views/DashboardView.vue'),
    },
    {
        name: 'vehicles',
        route: '/vehicles',
        title: 'Vehicles',
        placement: ['topbar'],
        layout: LayoutTopHeaderContentOnly,
        view: () => import('../modules/vehicles/views/VehiclesListView.vue'),

        // redirect: { name: 'vehicle-ledger' },
        children: [
            // {
            //     name: 'vehicle-ledger',
            //     route: 'list',
            //     title: 'Vehicles List',
            //     layout: LayoutTopHeaderContentOnly,
            //     view: () => import('../modules/vehicles/views/VehiclesListView.vue'),
            //     // view: () => import('../views/HomeView.vue'),
            // },
            // {
            //     name: 'vehicle-create',
            //     route: 'create',
            //     title: 'Vehicle Create',
            //     layout: LayoutTopHeaderContentOnly,
            //     view: () => import('../modules/vehicles/views/VehicleCreateView.vue'),
            //     // view: () => import('../views/HomeView.vue'),
            // }
        ]
    },
    {
        name: 'vehicle-create',
        route: '/vehicles/create',
        title: 'Vehicle Create',
        layout: LayoutTopHeaderContentOnly,
        view: () => import('../modules/vehicles/views/VehicleCreateView.vue'),
        // view: () => import('../views/HomeView.vue'),
    },
    {
        route: '/vehicle/:plateNo',
        title: 'Vehicle',
        name: 'vehicle',
        layout: LayoutTopHeaderWithSidebar,
        view: () => import('../modules/vehicles/views/VehicleMainView.vue'),
        redirect: { name: 'vehicle-profile' },
        children: [
            {
                name: 'vehicle-profile',
                route: 'profile',
                title: 'Profile',
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleProfileView.vue'),
            },
            {
                name: 'vehicle-gas-logs',
                route: 'gas-logs',
                title: 'Gas Logs',
                placement: ['sidebar'],
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleGasLogView.vue'),
            },
            {
                name: 'maintenance-logs',
                route: '/maintenance-logs',
                title: 'Maintenance Logs',
                placement: ['sidebar'],
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleGasLogView.vue'),
            },
            {
                name: 'odometer-logs',
                route: '/odometer-logs',
                title: 'Odometer Logs',
                placement: ['sidebar'],
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleGasLogView.vue'),
            },
            {
                name: 'trip-logs',
                route: '/trip-logs',
                title: 'Trip Logs',
                placement: ['sidebar'],
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleGasLogView.vue'),
            },
            {
                name: 'incident-logs',
                route: '/incident-report',
                title: 'Incident Reports',
                placement: ['sidebar'],
                layout: LayoutTopHeaderWithSidebar,
                view: () => import('../modules/vehicles/views/VehicleGasLogView.vue'),
            }
        ]
    },

    // {
    //     name: 'drivers',
    //     route: '/drivers',
    //     title: 'Drivers',
    //     children: [

    //     ]
    // },
    // {
    //     name: 'data-references',
    //     route: '/references',
    //     title: 'References',
    //     children: [

    //     ]
    // },
    // {
    //     name: 'fleet-operations',
    //     route: '/fleet-operations',
    //     title: 'Fleet Operations',
    //     children: [

    //     ]
    // },
];

export default NavigationMenu;