<template>
  <div v-for="post in props.posts" v-if="props.posts.length > 0" id="timeline-view">
    <Divider></Divider>
    <h3>
      {{ post.authorName }}
    </h3>
    <p>
      <b>
        <template v-if="post.datePosted != post.dateModified">
          {{ new Date(post.datePosted).toLocaleString() }}, Edited: {{ new Date(post.dateModified).toLocaleString() }}
        </template>
        <template v-else>
          {{ new Date(post.datePosted).toLocaleString() }}
        </template>
      </b>
    </p>
    <p>{{ post.message }}</p>
    <div :id="`like-dislike-${post.postId}`">
      <Button
        :label="''"
        class="p-button-text p-button-rounded p-button-secondary"
        icon="pi pi-thumbs-up"
      ></Button>
      <Button
        :label="''"
        class="p-button-text p-button-rounded p-button-secondary"
        icon="pi pi-thumbs-down"
      ></Button>
    </div>
  </div>

  <Divider></Divider>
  <h3 v-if="props.posts.length === 0" class="p-text-secondary text-center">
    Hmm... it seems as though no posts are here. Create one using the button on the sidebar.
  </h3>
  <ScrollTop />
</template>

<script lang="ts" setup>
import Divider from "primevue/divider";
import Button from "primevue/button";
import ScrollTop from "primevue/scrolltop";

const props = defineProps<{
  posts: Post[]
}>();
</script>
