<template>
  <v-app>
    <v-app-bar app color="secondary" dark>
      <div>
        <img src="./assets/logo-main_ententee.svg" alt="" />
        <span class="primary--text display-1 ml-3">WEB APP TEST</span>
      </div>
    </v-app-bar>

    <v-main>
      <LandingPage />
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
    //
  }),
});
</script>
