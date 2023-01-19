<template>
  <SidebarMenu :menu="menu" collapsed hide-toggle></SidebarMenu>
</template>

<script lang="ts" setup>
import { SidebarMenu } from "vue-sidebar-menu";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import { useUserStore } from "../../store/UserStore";
import { reactive, watch } from "vue";

const userStore = useUserStore();

// Min w: 1110px
const menu = reactive([
  {
    header: "Lsoc"
  },
  {
    title: "Timeline",
    icon: "pi pi-fw pi-hashtag",
    href: "/"
  },
  {
    title: "About",
    icon: "pi pi-fw pi-info-circle",
    href: "/about"
  },
  {
    title: "Log Out",
    icon: "pi pi-fw pi-sign-out",
    href: "/login?logout=true",
    needsAuth: true,
    hidden: true
  },
  {
    title: "Log In",
    icon: "pi pi-fw pi-sign-in",
    href: "/login",
    needsNoAuth: true,
    hidden: true
  }
]);

// Workaround: Reactivity doesn't work on the vue-sidebar-menu's menu component, so use a watcher
// to manually set hidden status for added properties needsAuth and needsNoAuth
watch(userStore.$state, (state) => {
  for (let item of menu) {
    if (item.needsAuth) {
      item.hidden = !state.authenticated;
    } else if (item.needsNoAuth) {
      item.hidden = state.authenticated;
    }
  }
});
</script>
