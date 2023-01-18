<template>
  <div v-for="post in props.posts" v-if="props.posts" id="timeline-view">
    <Divider></Divider>
    <h3>{{ new Date(post.datePosted).toLocaleString() }}</h3>
    <h6>Author</h6>
    <p>{{ post.message }}</p>
    <div :id="`like-dislike-${post.postId}`">
      <Button
        :label="'' + post.likes"
        class="p-button-text p-button-rounded p-button-secondary"
        icon="pi pi-thumbs-up"
      ></Button>
      <Button
        :label="'' + post.dislikes"
        class="p-button-text p-button-rounded p-button-secondary"
        icon="pi pi-thumbs-down"
      ></Button>
    </div>
    <ScrollTop />
  </div>
  <Divider></Divider>
</template>

<script lang="ts" setup>
import Divider from "primevue/divider";
import Button from "primevue/button";
import ScrollTop from "primevue/scrolltop";

const props = defineProps(["posts"]);
const name = "timelineView";
</script>
