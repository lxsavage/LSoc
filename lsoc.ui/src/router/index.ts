// @ts-ignore
export default [
    {
        path: '/',
        name: 'Dashboard',
        component: () => import('../pages/Dashboard.vue')
    },
    {
        path: '/about',
        name: 'About',
        component: () => import('../pages/About.vue')
    }
]