<template>
  <div>
    <v-form ref="form">
      <v-text-field
        v-model="form.email"
        prepend-icon="mdi-email"
        label="Email"
        type="email"
        validate-on-blur
        autocomplete="username"
        :rules="[isEmail]"
      ></v-text-field>
      <v-text-field
        v-model="form.firstName"
        prepend-icon="mdi-account-details"
        required
        :rules="[
          () => !!form.firstName || 'First name is required',
          isMaxLengthValid(50),
        ]"
        label="First Name"
        validate-on-blur
        type="text"
      ></v-text-field>
      <v-text-field
        v-model="form.lastName"
        prepend-icon="mdi-account-details"
        required
        :rules="[
          () => !!form.lastName || 'Last name is required',
          isMaxLengthValid(50),
        ]"
        label="Last Name"
        validate-on-blur
        type="text"
      ></v-text-field>
      <DatePicker v-model="form.birthday"></DatePicker>
      <v-text-field
        v-model="form.password"
        prepend-icon="mdi-lock"
        label="Password"
        type="password"
        validate-on-blur
        autocomplete="new-password"
        :rules="[isValidPassword]"
      ></v-text-field>
      <v-text-field
        v-model="repeatPassword"
        prepend-icon="mdi-repeat"
        label="Repeat Password"
        type="password"
        validate-on-blur
        autocomplete="new-password"
        :rules="[isPasswordSame]"
      ></v-text-field>
      <v-btn color="primary" type="button" @click="signup" class="mt-5"
        >Register</v-btn
      >
    </v-form>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import UserRegistration from "@/models/user-registration";
import UserService from "@/services/user-service";
import validators from "@/helpers/validators";
import DatePicker from "@/components/DatePicker.vue";

export default Vue.extend({
  name: "Register",
  components: {
    DatePicker,
  },
  data() {
    return {
      form: new UserRegistration(),
      repeatPassword: "",
    };
  },
  methods: {
    ...validators,
    async signup() {
      // @ts-expect-error
      if (!this.$refs.form.validate()) return;
      this.$emit("isLoading", true);
      try {
        const user = await UserService.register(this.form);
        this.$toast.success(`User ${user?.email} created`);
        this.$emit("signedUp");
      } catch (error: any) {
        this.$toast.error(error.message);
        this.$emit("userExists");
      } finally {
        this.$emit("isLoading", false);
      }
    },
    isPasswordSame(value: string): boolean | string {
      return value === this.form.password || "Passwords do not match";
    },
  },
});
</script>
