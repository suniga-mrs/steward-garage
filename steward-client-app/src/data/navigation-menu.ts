export interface INavigationItem {
    name: string,
    route: string,
    title: string,
    children?: Array<INavigationItem>
};

export type TNavigationMenu = Array<INavigationItem>;

const NavigationMenu: TNavigationMenu = [
    {
        name: 'vehicles',
        route: '/vehicles',
        title: "Vehicles",
        children: [
            {
                name: 'gas-logs',
                route: '/gas-logs',
                title: 'Gas Logs',
            }, {
                name: 'maintenance-logs',
                route: '/maintenance-logs',
                title: 'Maintenance Logs',
            }, {
                name: 'odometer-logs',
                route: '/odometer-logs',
                title: 'Odometer Logs',
            }, {
                name: 'trip-logs',
                route: '/trip-logs',
                title: 'Trip Logs',
            }, {
                name: 'incident-logs',
                route: '/incident-report',
                title: 'Incident Reports',
            }
        ]
    },
    {
        name: 'drivers',
        route: '/drivers',
        title: "Drivers",
        children: [

        ]
    },
    {
        name: 'data-references',
        route: '/references',
        title: "References",
        children: [

        ]
    },
    {
        name: 'drivers',
        route: '/drivers',
        title: "Drivers",
        children: [

        ]
    },
];

export default NavigationMenu;