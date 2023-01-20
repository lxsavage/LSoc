<template>
  <h1>{{ name }}</h1>
  <form @submit.prevent="handleSubmission">
    <Textarea v-model="currentContent"></Textarea>
  </form>
</template>

<script lang="ts" setup>
import { ref } from "vue";
import Textarea from "primevue/textarea";

const name = "Create New Post";

const currentContent = ref("");

async function handleSubmission() {
  if (currentContent.value.length > 0) {
    // Attempt posting as current user
  }
}
</script>