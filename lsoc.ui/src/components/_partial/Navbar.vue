<template>
  <Menubar :model="items" class="sticky">
  </Menubar>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Menubar from 'primevue/menubar'
const name = 'Navigation'

const items = ref([
  {
    label: 'Dashboard',
    icon: 'pi pi-fw pi-file',
    url: '/#/'
  },
  {
    label: 'About',
    icon: 'pi pi-fw pi-file',
    url: '/#/about'
  }
])
</script>