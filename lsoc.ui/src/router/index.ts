export default [
  {
    path: "/",
    name: "Dashboard",
    component: () => import("../pages/Dashboard.vue")
  },
  {
    path: "/new",
    name: "New Post",
    component: () => import("../pages/Create.vue")
  },
  {
    path: "/about",
    name: "About",
    component: () => import("../pages/About.vue")
  },
  {
    path: "/login",
    name: "Sign In",
    component: () => import("../pages/Login.vue")
  },
  {
    path: "/logout",
    name: "Sign Out",
    redirect: {
      path: "/login",
      params: {
        logout: true
      }
    }
  }
];
