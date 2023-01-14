import { defineStore } from 'pinia'

export const usePostStore = defineStore('posts', {
  state: () => ({
    loadedPosts: []
  }),
})