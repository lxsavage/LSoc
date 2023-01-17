<template>
  <h1>{{ name }}</h1>

  <ProgressBar
    v-if="postsLoading"
    mode="indeterminate"
    style="height: 0.5em"
  ></ProgressBar>
  <TimelineView :posts="loadedPosts"></TimelineView>
  <Divider></Divider>
</template>

<script setup lang="ts">
import { onBeforeMount } from "vue";
import { usePostsStore } from "../store/PostsStore";
import { storeToRefs } from "pinia";

import TimelineView from "../components/posts/TimelineView.vue";

import Divider from "primevue/divider";
import ProgressBar from "primevue/progressbar";

const name = "Your Timeline";

const postsStore = usePostsStore();
const { loadedPosts, postsLoading } = storeToRefs(postsStore);
const { fetchPosts } = postsStore;

// Fetch all posts automatically upon navigating to the dashboard
onBeforeMount(async () => {
  await fetchPosts();
});
</script>
