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
      <v-btn color="primary" type="button" @click="signup">Login</v-btn>
    </v-form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import UserRegistration from "@/models/user-registration";
import UserService from "@/services/user-service";

export default Vue.extend({
  name: "Register",
  data() {
    return {
      form: new UserRegistration(),
    };
  },
  methods: {
    async signup() {
      // @ts-expect-error
      if (!this.$refs.form.validate()) return;

      try {
        const user = await UserService.register(this.form);
        console.log({ user });
      } catch (error: any) {
        this.$toast.error(error.message);
        this.$emit("userExists");
      }
    },
  },
});
</script>
