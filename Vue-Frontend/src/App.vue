<template>
  <v-app>
    <v-toolbar
      flat
      color="indigo lighten-1"
      class="py-1"
    >
      <!-- <v-toolbar-side-icon ></v-toolbar-side-icon> -->
      <v-toolbar-title>
        <span class="px-2 white--text font-weight-bold display-3 black">KiwiLink</span>
        <span class="display-1">CRM</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items class="hidden-sm-and-down">
        <v-btn flat>Link One</v-btn>
        <v-btn flat>Link Two</v-btn>
        <v-btn flat>Link Three</v-btn>
      </v-toolbar-items>
    </v-toolbar>

    <v-content>
      <router-view />
    </v-content>
  </v-app>
</template>

<script>
export default {
  name: "App",
  data() {
    return {};
  }
};
</script>
