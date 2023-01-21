<template>
  <div :hidden="!props.visible">
    <SidebarMenu :menu="menu" collapsed hide-toggle @item-click="handleItemClick"></SidebarMenu>
  </div>
</template>

<script lang="ts" setup>
import { defineProps, reactive } from "vue";
import { SidebarMenu } from "vue-sidebar-menu";
import { useDialog } from "naive-ui";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import { useRouter } from "vue-router";

const router = useRouter();
const dialog = useDialog();

const props = defineProps<{
  visible?: boolean
}>();

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
    title: "About This Project",
    icon: "pi pi-fw pi-info-circle",
    href: "/about"
  },
  {
    title: "Log Out",
    icon: "pi pi-fw pi-sign-out"
  }
]);

function handleItemClick(event: PointerEvent, item: { title: string }) {
  if (item.title === "Log Out") {
    dialog.warning({
      title: "Log Out Confirmation",
      content: "Are you sure you want to log out?",
      positiveText: "Yes",
      negativeText: "No",
      onPositiveClick: () => router.push({ path: "/login", query: { logout: "true" } })
    });
  }
}
</script>
