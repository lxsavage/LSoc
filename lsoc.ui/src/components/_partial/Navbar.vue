<template>
  <SidebarMenu :menu="menu" collapsed hide-toggle></SidebarMenu>
</template>

<script lang="ts" setup>
import { SidebarMenu } from "vue-sidebar-menu";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";

// Placeholder: replace after implementing authentication
const authenticated: boolean = false;

// Min w: 1110px
const menu = [
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
  }
];

if (authenticated) {
  menu.push({
    title: "Log Out",
    icon: "pi pi-fw pi-sign-out",
    href: "/logout"
  });
} else {
  menu.push({
    title: "Log In",
    icon: "pi pi-fw pi-sign-in",
    href: "/login"
  });
}
</script>
