<template>
  <div>
    <div class="container">
      <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <h1>{{ title }}</h1>
          <hr />
          <v-card>
            <v-card-text>
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
                <v-btn color="primary" type="submit" @click="login"
                  >Login</v-btn
                >
              </v-form>
            </v-card-text>
          </v-card>
        </div>
      </div>
    </div>
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
      if (this.$refs.form.validate()) {
        const user = await UserService.login(
          this.form.email,
          this.form.password
        );
        console.log({ user });
      }
    },
  },
});
</script>
