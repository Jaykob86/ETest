<template>
  <v-menu
    ref="menu"
    v-model="menu"
    :close-on-content-click="false"
    transition="scale-transition"
    offset-y
    min-width="auto"
  >
    <template v-slot:activator="{ on, attrs }">
      <v-text-field
        v-model="date"
        label="Birthday date"
        prepend-icon="mdi-calendar"
        readonly
        required
        :rules="[isDateValid, dateRequired]"
        v-bind="attrs"
        v-on="on"
      ></v-text-field>
    </template>
    <v-date-picker
      v-model="date"
      :active-picker.sync="activePicker"
      :max="
        new Date(Date.now() - new Date().getTimezoneOffset() * 60000)
          .toISOString()
          .substr(0, 10)
      "
      min="1950-01-01"
      @change="save"
    ></v-date-picker>
  </v-menu>
</template>

<script lang="ts">
import validators from "@/helpers/validators";
import Vue from "vue";

export default Vue.extend({
  data: () => ({
    activePicker: null as string | null,
    date: null,
    menu: false,
  }),
  watch: {
    menu(val) {
      val && setTimeout(() => (this.activePicker = "YEAR"));
    },
  },
  methods: {
    ...validators,
    save(date: Date) {
      // @ts-expect-error
      this.$refs.menu.save(date);
      this.$emit("input", date);
    },
  },
});
</script>
