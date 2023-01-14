import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'

import './style.scss'
import PrimeVue from 'primevue/config'

import 'primevue/resources/themes/saga-blue/theme.css';
import 'primevue/resources/primevue.min.css';
import 'primeicons/primeicons.css';


import { createRouter, createWebHashHistory } from 'vue-router'
import routes from './router/index'

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

const pinia = createPinia()
const app = createApp(App)

app.use(router)
app.use(pinia)
app.use(PrimeVue)
app.mount('#app')