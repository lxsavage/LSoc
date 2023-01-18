import { defineStore } from "pinia";
import { mande, MandeInstance } from "mande";

const postsApi: MandeInstance = mande("http://localhost:8080/api/post");

export const usePostStore = defineStore("posts", {
  state: () => ({
    loadedPosts: Array<Post>(),
    postsLoading: true
  }),
  actions: {
    async fetchPosts() {
      try {
        this.postsLoading = true;
        const posts: any = postsApi.get("");
        // Clear the array
        this.loadedPosts.splice(0);

        // Fill the posts array with the retrieved posts
        for (const post of await posts) {
          this.loadedPosts.push(post);
        }
      } catch (e) {
        console.error(e);
      } finally {
        this.postsLoading = false;
      }
    }
  }
});
