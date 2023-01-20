<template>
  <Navbar :visible="userStore.authenticated"></Navbar>
  <div class="main-container">
    <main class="mx-auto max-w-30rem">
      <router-view></router-view>
    </main>
  </div>
</template>

<script lang="ts" setup>
import Navbar from "./components/_partial/Navbar.vue";
import { useUserStore } from "./store/UserStore";

const userStore = useUserStore();
</script>