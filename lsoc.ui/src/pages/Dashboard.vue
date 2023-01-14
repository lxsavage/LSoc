<template>
  <h1 class="text-2xl">{{ name }}</h1>
  <p>{{ message }}</p>
  <p>{{ count }}</p>
  <Button @click="increment">Click me!</Button>
</template>

<script setup lang="ts">
import { useHelloWorldStore } from '../store/HelloWorldStore'
import { storeToRefs } from "pinia";
import Button from 'primevue/button'

const hwStore = useHelloWorldStore()
const { message, count } = storeToRefs(hwStore)
const { increment } = hwStore
</script>