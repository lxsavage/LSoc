<template>
  <div v-for="post in props.posts" v-if="props.posts" id="timeline-view">
    <Divider></Divider>
    <h3>
      Author
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
  <ScrollTop />
</template>

<script lang="ts" setup>
import Divider from "primevue/divider";
import Button from "primevue/button";
import ScrollTop from "primevue/scrolltop";

const props = defineProps(["posts"]);
</script>
