<template>
  <h1>{{ userStore.authenticated ? userStore.currentUser.username : "User" }}{{ name }}</h1>
  <PostCreationTextbox></PostCreationTextbox>
  <TimelineView :loading="postsStore.postsLoading" :posts="postsStore.loadedPosts"></TimelineView>
</template>

<script lang="ts" setup>
import { onBeforeMount } from "vue";
import { usePostStore } from "../store/PostStore";
import { useUserStore } from "../store/UserStore";
import { useLoadingBar } from "naive-ui";

import TimelineView from "../components/posts/TimelineView.vue";
import PostCreationTextbox from "../components/posts/PostCreationTextbox.vue";

const name: string = "'s Timeline";

const loadingBar = useLoadingBar();
const postsStore = usePostStore();
const userStore = useUserStore();

// Fetch all posts automatically upon navigating to the dashboard
onBeforeMount(async () => {
  loadingBar.start();
  await postsStore.fetchPosts();
  loadingBar.finish();
});
</script>
