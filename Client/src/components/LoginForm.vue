<template>
  <div>
    <v-form ref="form">
      <v-text-field
        v-model="form.email"
        label="Email"
        type="email"
      ></v-text-field>
      <v-text-field
        v-model="form.password"
        label="Password"
        type="password"
      ></v-text-field>
      <v-btn color="primary" type="button" @click="login">Login</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import UserService from "@/services/user-service";
import Vue from "vue";

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
    async login() {
      // @ts-expect-error
      if (!this.$refs.form.validate()) return;

      try {
        const user = await UserService.login(
          this.form.email,
          this.form.password
        );
        console.log({ user });
      } catch (error: any) {
        this.$toast.error(error.message);
      }
    },
  },
});
</script>
