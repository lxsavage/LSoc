<template>
  <n-loading-bar-provider>
    <n-dialog-provider>
      <Navbar :visible="userStore.authenticated"></Navbar>
      <n-space class="main-container" justify="center">
        <main class="main-content">
          <router-view></router-view>
        </main>
      </n-space>
    </n-dialog-provider>
  </n-loading-bar-provider>
</template>

<script lang="ts" setup>
import Navbar from "./components/_partial/Navbar.vue";
import { useUserStore } from "./store/UserStore";
import { NDialogProvider, NLoadingBarProvider, NSpace } from "naive-ui";

const userStore = useUserStore();
</script>

<style scoped>
.main-container {
  margin-left: 65px;
}

.main-content {
  width: 30rem;
}
</style>