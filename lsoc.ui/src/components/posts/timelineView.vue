<template>
  <div id="timeline-view" v-if="props.posts" v-for="post in props.posts">
    <Divider></Divider>
    <h3>{{ new Date(post.datePosted).toLocaleString() }} </h3>
    <h6>Author</h6>
    <p>{{ post.message }}</p>
    <div :id="`like-dislike-${post.postId}`">
      <Button icon="pi pi-thumbs-up" :label="''+post.likes" class="p-button-text p-button-rounded p-button-secondary"></Button>
      <Button icon="pi pi-thumbs-down" :label="''+post.dislikes" class="p-button-text p-button-rounded p-button-secondary"></Button>
    </div>
    <ScrollTop />
  </div>
</template>

<script setup lang="ts">
import Divider from 'primevue/divider'
import Button from 'primevue/button'
import ScrollTop from 'primevue/scrolltop'

const props = defineProps(['posts'])
const name = "timelineView"
</script>