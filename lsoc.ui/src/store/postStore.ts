import { defineStore } from 'pinia'
import PostsHelper from '../helpers/postsHelper'

export const usePostStore = defineStore('posts', {
  state: () => ({
    loadedPosts: []
  }),
  actions: {
    retrievePosts: async () => {
      const posts = await PostsHelper.getPosts()
      for (const post of posts) {
        this.loadedPosts.push(post)
      }
    }
  }
})