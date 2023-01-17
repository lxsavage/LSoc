<template>
  <Navbar></Navbar>
  <main class="main-container">
    <router-view></router-view>
  </main>
</template>

<script setup lang="ts">
import Navbar from "./components/_partial/Navbar.vue"
</script>