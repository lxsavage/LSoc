import { defineStore } from "pinia";
import { login, logout, userInfo } from "../helpers/authHelper";
import { reactive } from "vue";

export const useUserStore = defineStore("user", {
  state: () => ({
    currentUser: {} as User,
    authenticated: false,
    loading: false
  }),
  actions: {
    async login(credentials: UserLogin) {
      const user: User | null = await login(credentials);
      if (user) {
        this.currentUser = reactive(user);
        this.authenticated = true;
      }
    },
    async logout() {
      if (!this.authenticated) return;

      await logout();
      this.currentUser = {} as User;
      this.authenticated = false;
    },
    async fetchMe() {
      const me: User | null = await userInfo();
      if (me) {
        this.currentUser = reactive(me);
        this.authenticated = true;
      } else {
        this.currentUser = {} as User;
        this.authenticated = false;
      }
    }
  }
});
