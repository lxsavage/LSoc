import { defineStore } from "pinia";
import { mande, MandeInstance } from "mande";

const userApi: MandeInstance = mande("http://localhost:8080/api/user");

export const useUserStore = defineStore("user", {
  state: () => ({
    currentUser: null,
    authenticated: false,
    loading: false
  }),
  actions: {
    async attemptSignIn(credentials: User) {
      try {
        this.loading = true;
        const response: Response = await userApi.post("", credentials, {
          responseAs: "response"
        });

        if (response.status == 200) {
          const body: string = response && response.body ? response.body.toString() : "";
          
          this.authenticated = true;
          this.currentUser = JSON.parse(body);
        }
      } catch (e) {
        console.error(e);
      } finally {
        this.loading = false;
      }
    }
  }
});
