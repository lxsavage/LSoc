<template>
  <form @submit.prevent="attemptLogin">
    <Card role="form">
      <template #title>
        {{ name }}
      </template>
      <template v-if="userStore.loginError" #subtitle>
        <p class="p-text-danger">Error with sign in; please check your username and password, then try to sign in
          again.</p>
      </template>
      <template #content>
        <div>
          <span class="p-float-label mt-2">
            <InputText
              id="username"
              v-model="user.username"
              class="max-width-field"
              type="text"
            ></InputText>
            <label for="username">Username</label>
          </span>
          <span class="p-float-label mt-5">
            <InputText
              id="password"
              v-model="user.password"
              class="max-width-field"
              type="password"
            ></InputText>
            <label for="password">Password</label>
          </span>
        </div>
      </template>
      <template #footer>
        <Button label="Sign In" type="submit"></Button>
      </template>
    </Card>
  </form>
</template>

<script lang="ts" setup>
import { useUserStore } from "../store/UserStore";
import Card from "primevue/card";
import InputText from "primevue/inputtext";
import Button from "primevue/button";

import { Ref, ref } from "vue";
import { useRoute, useRouter } from "vue-router";

const userStore = useUserStore();
const router = useRouter();
const route = useRoute();

const name: string = "Log In";
const user: Ref<UserLogin> = ref<UserLogin>({
  username: "",
  password: ""
});

async function attemptLogin() {
  await userStore.login(user.value);
  if (userStore.authenticated) {
    await router.push({ path: "/" });
  }
}

// If the user was brought here through the logout button (will have the logout query param set to true), then log them out
if (userStore.authenticated && route.query.logout) {
  userStore.logout();
}
</script>

<style>
.max-width-field {
  width: 100%;
}
</style>
