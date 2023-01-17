<template>
  <form @submit.prevent="attemptLogin">
    <Card>
      <template #title>
        {{ name }}
      </template>
      <template #content>
        <div>
        <span class="p-float-label mt-2">
          <InputText id="username" type="text" v-model="user.username" class="max-width-field"></InputText>
          <label for="username">Username</label>
        </span>
          <span class="p-float-label mt-5">
          <InputText id="password" type="password" v-model="user.password" class="max-width-field"></InputText>
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

<script setup lang="ts">
import Card from "primevue/card";
import InputText from "primevue/inputtext";
import Button from "primevue/button";

import { ref } from "vue";

const user = ref({
  username: "",
  password: "",
});

const name = "Log In";

function attemptLogin() {
  console.log(user)
}
</script>

<style>
.max-width-field {
  width: 100%;
}
</style>