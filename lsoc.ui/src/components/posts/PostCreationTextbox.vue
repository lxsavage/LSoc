<template>
  <n-input-group>
    <n-input v-model:value="writtenMessage"
             :count-graphemes="countGraphemes"
             :maxlength="144"
             placeholder="What are your thoughts?"
             show-count
             type="text" />
    <n-button class="right-button" @click="handlePostCreation">
      <template #icon>
        <i class="pi pi-send"></i>
      </template>
    </n-button>
  </n-input-group>
</template>

<script lang="ts" setup>
import { ref } from "vue";
import { NButton, NInput, NInputGroup } from "naive-ui";
import GraphemeSplitter from "grapheme-splitter";
import { usePostStore } from "../../store/PostStore";

const postStore = usePostStore();

const splitter = new GraphemeSplitter();
const writtenMessage = ref("");

async function handlePostCreation() {
  if (writtenMessage.value.length > 0) {
    await postStore.createPost(writtenMessage.value);
    writtenMessage.value = "";
  }
}

function countGraphemes(value: string) {
  return splitter.countGraphemes(value);
}
</script>

<style scoped>
.right-button {
  justify-self: right;
}
</style>