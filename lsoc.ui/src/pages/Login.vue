<template>
  <n-form :disabled="submitting" :model="user">
    <n-card :title="name">
      <!-- Form Body -->
      <n-form-item label="Username" path="username">
        <n-input v-model:value="user.username" placeholder="JSmith" type="text"></n-input>
      </n-form-item>
      <n-form-item label="Password" path="password">
        <n-input v-model:value="user.password" placeholder="Password" type="password"></n-input>
      </n-form-item>

      <!-- Error Section -->
      <template v-if="userStore.loginError" #footer>
        <p class="p-text-danger">
          Error with sign in; please check your username and password, then try to sign in again.
        </p>
      </template>

      <!-- Form Action -->
      <template #action>
        <n-button :disabled="submitting" type="primary" @click="attemptLogin">Sign In</n-button>
      </template>
    </n-card>
  </n-form>
</template>

<script lang="ts" setup>
import { useUserStore } from "../store/UserStore";
import { useRoute, useRouter } from "vue-router";

import { NButton, NCard, NForm, NFormItem, NInput, useLoadingBar } from "naive-ui";
import { ref } from "vue";

const loadingBar = useLoadingBar();

const userStore = useUserStore();
const router = useRouter();
const route = useRoute();

const name: string = "Log In";
const submitting = ref(false);
const user = ref({
  username: "",
  password: ""
});

async function attemptLogin() {
  submitting.value = true;
  loadingBar.start();

  await userStore.login(user.value);
  if (userStore.authenticated) {
    loadingBar.finish();
    await router.push({ path: "/" });
  }

  loadingBar.error();
  submitting.value = false;
}

// If the user was brought here through the logout button (will have the logout query param set to true), then log them out
if (userStore.authenticated && route.query.logout) {
  userStore.logout();
}
</script>