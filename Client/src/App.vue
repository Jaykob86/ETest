<template>
  <v-app>
    <v-app-bar app color="secondary" dark>
      <div>
        <img src="./assets/logo-main_ententee.svg" alt="" />
        <span class="primary--text display-1 ml-3">WEB APP TEST</span>
      </div>
      <v-spacer></v-spacer>
      <span v-if="user" class="mr-5">{{ user.email }}</span>
      <v-btn v-if="user" icon fab @click="logout" title="Logout"
        ><v-icon color="primary">mdi-logout</v-icon></v-btn
      >
    </v-app-bar>

    <v-main>
      <v-fade-transition mode="out-in">
        <LandingPage v-if="!user" @userLoggedIn="user = $event" />
        <v-card v-else height="500px" class="d-flex">
          <v-card-title class="grow justify-center display-1">
            Login successful... enjoy the app! 🙂
          </v-card-title>
        </v-card>
      </v-fade-transition>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import LandingPage from "./views/LandingPage.vue";

export default Vue.extend({
  name: "App",

  components: {
    LandingPage,
  },

  data: () => ({
    user: null,
  }),

  methods: {
    logout() {
      this.user = null;
      this.$toast.success("User logged out");
    },
  },
});
</script>
