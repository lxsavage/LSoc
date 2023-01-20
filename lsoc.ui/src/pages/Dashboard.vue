<template>
  <h1>{{ userStore.authenticated ? userStore.currentUser.username : "User" }}{{ name }}</h1>

  <ProgressBar
    v-if="postsLoading"
    mode="indeterminate"
    style="height: 0.5em"
  ></ProgressBar>
  <TimelineView :posts="loadedPosts"></TimelineView>
</template>

<script lang="ts" setup>
import { onBeforeMount } from "vue";
import { storeToRefs } from "pinia";
import { usePostStore } from "../store/PostStore";
import { useUserStore } from "../store/UserStore";

import TimelineView from "../components/posts/TimelineView.vue";
import ProgressBar from "primevue/progressbar";

const name: string = "'s Timeline";

const postsStore = usePostStore();
const userStore = useUserStore();

const { loadedPosts, postsLoading } = storeToRefs(postsStore);

// Fetch all posts automatically upon navigating to the dashboard
onBeforeMount(async () => {
  await postsStore.fetchPosts();
});
</script>
