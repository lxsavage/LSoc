<template>
  <div :hidden="!props.visible">
    <SidebarMenu :menu="menu" collapsed hide-toggle @item-click="handleItemClick"></SidebarMenu>
    <Dialog :closable="false" :draggable="false" :visible="logoutModalActive" header="Log Out Confirmation" modal
            position="topleft">
      Are you sure you want to log out?
      <template #footer>
        <Button class="p-button-text p-text-secondary" label="No" @click="handleLogoutModalResponse(false)" />
        <Button class="p-button-danger" label="Yes" @click="handleLogoutModalResponse(true)" />
      </template>
    </Dialog>
  </div>
</template>

<script lang="ts" setup>
import { SidebarMenu } from "vue-sidebar-menu";
import "vue-sidebar-menu/dist/vue-sidebar-menu.css";
import { defineProps, reactive, ref } from "vue";
import Dialog from "primevue/dialog";
import Button from "primevue/button";
import { useRouter } from "vue-router";

const props = defineProps<{
  visible?: boolean
}>();
const router = useRouter();

const logoutModalActive = ref(false);

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
    title: "New Post",
    icon: "pi pi-fw pi-pencil",
    href: "/new"
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
  logoutModalActive.value = item.title === "Log Out";
}

function handleLogoutModalResponse(confirmed: boolean) {
  logoutModalActive.value = false;

  if (confirmed) {
    router.push({ path: "/login", query: { logout: "true" } });
  }
}
</script>
