<template>
  <div>
    <v-form ref="form">
      <v-text-field
        v-model="form.email"
        prepend-icon="mdi-email"
        label="Email"
        type="email"
        required
        validate-on-blur
        :rules="[isEmail]"
      ></v-text-field>
      <v-text-field
        v-model="form.password"
        prepend-icon="mdi-lock"
        label="Password"
        type="password"
        required
        autocomplete="current-password"
      ></v-text-field>
      <v-btn color="primary" type="button" @click="login" class="mt-5"
        >Login</v-btn
      >
    </v-form>
  </div>
</template>

<script lang="ts">
import UserService from "@/services/user-service";
import Vue from "vue";
import { isEmail } from "@/helpers/validators";

export default Vue.extend({
  name: "Login",
  data() {
    return {
      title: "Login",
      form: {
        email: "",
        password: "",
      },
    };
  },
  methods: {
    isEmail,
    async login() {
      // @ts-expect-error
      if (!this.$refs.form.validate()) return;
      this.$emit("isLoading", true);
      try {
        const user = await UserService.login(
          this.form.email,
          this.form.password
        );
        this.$emit("userLoggedIn", user);
        this.$toast.success(`User ${user?.email} logged in`);
      } catch (error: any) {
        this.$toast.error(error.message);
      } finally {
        this.$emit("isLoading", false);
      }
    },
  },
});
</script>
