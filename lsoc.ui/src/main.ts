// Vue app
import { createApp } from "vue";
import App from "./App.vue";

// Router
import { createRouter, createWebHistory, Router } from "vue-router";
import routes from "./router/index";

// Store
import { createPinia, Pinia } from "pinia";

// Styling
import PrimeVue from "primevue/config";
import "primevue/resources/themes/saga-blue/theme.css";
import "primevue/resources/primevue.min.css";
import "primeicons/primeicons.css";
import "./style.scss";
import { useUserStore } from "./store/UserStore";

// Initialize plugins
const app: App = createApp(App);
const pinia: Pinia = createPinia();
const router: Router = createRouter({
  history: createWebHistory(),
  routes
});

// Router login guard
router.beforeEach(async (to, from, next) => {
  const userStore = useUserStore();
  await userStore.fetchMe();

  if (to.path != "/login" && !userStore.authenticated) next("/login");
  next();
});

// Include plugins in app, then mount the app to the webpage
app.use(router);
app.use(pinia);
app.use(PrimeVue);
app.mount("#app");
