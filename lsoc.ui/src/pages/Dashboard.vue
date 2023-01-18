<template>
  <h1>{{ name }}</h1>

  <ProgressBar
    v-if="postsLoading"
    mode="indeterminate"
    style="height: 0.5em"
  ></ProgressBar>
  <TimelineView :posts="loadedPosts"></TimelineView>
</template>

<script lang="ts" setup>
import { onBeforeMount } from "vue";
import { usePostStore } from "../store/PostStore";
import { storeToRefs } from "pinia";

import TimelineView from "../components/posts/TimelineView.vue";
import ProgressBar from "primevue/progressbar";

const name = "Your Timeline";

const postsStore = usePostStore();
const { loadedPosts, postsLoading } = storeToRefs(postsStore);
const { fetchPosts } = postsStore;

// Fetch all posts automatically upon navigating to the dashboard
onBeforeMount(async () => {
  await fetchPosts();
});
</script>
