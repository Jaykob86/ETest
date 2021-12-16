<template>
  <div>
    <div class="container mt-5">
      <div class="row">
        <div class="col-md-8 offset-md-2">
          <v-card :loading="isLoading" min-height="500px">
            <v-card-title class="secondary px-0 pb-0 pt-2 mb-5" flat>
              <v-flex xs12 class="text-center display-2 primary--text my-5">
                Welcome!
              </v-flex>
              <v-tabs
                v-model="tab"
                centered
                icons-and-text
                grow
                dark
                background-color="secondary"
                slider-color="primary"
              >
                <v-tab key="registerForm">
                  <v-layout class="text-centered column" justify-end>
                    <v-icon x-large color="primary">mdi-account-check</v-icon>
                    <span class="primary--text">Sign Up</span>
                  </v-layout>
                </v-tab>
                <v-tab key="loginForm">
                  <v-layout class="text-centered column" justify-end>
                    <v-icon x-large color="primary">mdi-login-variant</v-icon>
                    <span class="primary--text">Sign In</span>
                  </v-layout>
                </v-tab>
              </v-tabs>
            </v-card-title>

            <v-card-text>
              <v-tabs-items v-model="tab" class="pa-5">
                <v-tab-item>
                  <RegistrationForm
                    @userExists="tab = 1"
                    @signedUp="tab = 1"
                    @isLoading="isLoading = $event"
                  />
                </v-tab-item>

                <v-tab-item>
                  <LoginForm
                    @userLoggedIn="$emit('userLoggedIn', $event)"
                    @isLoading="isLoading = $event"
                  />
                </v-tab-item>
              </v-tabs-items>
            </v-card-text>
            <v-overlay
              v-if="isLoading"
              absolute
              color="white"
              opacity="0.5"
            ></v-overlay>
          </v-card>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import RegistrationForm from "@/components/RegistrationForm.vue";
import LoginForm from "@/components/LoginForm.vue";

export default Vue.extend({
  data() {
    return {
      tab: 1,
      isLoading: false,
    };
  },
  components: { RegistrationForm, LoginForm },
});
</script>
