<template>
  <div v-for="post in props.posts" v-if="props.posts.length > 0">
    <n-divider />
    <h3>
      {{ post.authorName }}
    </h3>
    <p>
      <b>
        <template v-if="post.datePosted != post.dateModified">
          {{ formatDate(post.datePosted) }}, Edited: {{ formatDate(post.dateModified) }}
        </template>
        <template v-else>
          {{ formatDate(post.datePosted) }}
        </template>
      </b>
    </p>
    <p>{{ post.message }}</p>
    <div :id="`like-dislike-${post.postId}`">
      <n-button circle disabled quaternary>
        <template #icon>
          <i class="pi pi-thumbs-up"></i>
        </template>
      </n-button>
      <n-button circle disabled quaternary>
        <template #icon>
          <i class="pi pi-thumbs-down"></i>
        </template>
      </n-button>
      <n-button v-if="isMyPost(post.authorId)" circle quaternary @click="handleDelete(post)">
        <template #icon>
          <i class="pi pi-trash"></i>
        </template>
      </n-button>
    </div>
  </div>

  <n-divider />
  <h3 v-if="props.posts.length === 0 && !props.loading" class="p-text-secondary text-center">
    Hmm... it seems as though no posts are here. Be the first to make one!
  </h3>
</template>

<script lang="ts" setup>
import { NButton, NDivider, useDialog } from "naive-ui";
import { useUserStore } from "../../store/UserStore";
import { usePostStore } from "../../store/PostStore";

const dialog = useDialog();
const userStore = useUserStore();
const postStore = usePostStore();

const props = defineProps<{
  posts: Post[],
  loading: boolean
}>();

function isMyPost(postId: string): boolean {
  return userStore.currentUser.userId === postId;
}

function formatDate(dateRaw: string): string {
  return new Date(dateRaw).toLocaleDateString();
}

async function handleDelete(post: Post) {
  if (isMyPost(post.authorId)) {
    // Confirm
    dialog.warning({
      title: "Deletion Confirmation",
      content: "Are you sure you want to delete this post?",
      positiveText: "Yes",
      negativeText: "No",
      onPositiveClick: async () => await postStore.deletePost(post.postId)
    });
  }
}
</script>
