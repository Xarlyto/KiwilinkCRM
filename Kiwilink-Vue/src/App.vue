<template>
  <v-app class="app">
    <v-content>
      <tool-bar />
      <v-container v-if="!Employee">
        <v-dialog
          v-model="Login.ShowForm"
          max-width="500px"
          persistent
        >
          <v-card class="pa-3">
            <v-card-title class="pa-3">
              <h2 class="blue--text">Please Log In...</h2>
            </v-card-title>
            <v-card-text class="pb-0">
              <v-text-field
                label="USERNAME"
                box
                v-model="Login.Username"
              ></v-text-field>
              <v-text-field
                label="PASSWORD"
                box
                type="password"
                v-model="Login.Password"
                @keypress.enter="authenticate"
              ></v-text-field>
            </v-card-text>
            <v-card-actions>
              <v-btn
                dark
                color="green darken-3"
                class="ml-2"
                :loading="Login.Authenticating"
                @click="authenticate"
              >
                <v-icon class="mr-2">fa-sign-in-alt</v-icon> Log In
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-container>
      <v-container
        v-if="Employee"
        grid-list-lg
      >
        <v-layout
          row
          wrap
        >
          <v-flex
            xs12
            md7
          >
            <v-progress-linear
              v-if="Loading"
              color="green"
              height="3"
              indeterminate
            ></v-progress-linear>
            <client />
            <teasers />
          </v-flex>
          <v-flex
            xs12
            md5
          >
            <finder />
            <tasks />
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import ToolBar from "./cmp/ToolBar";
import Teasers from "./cmp/Teasers";
import Finder from "./cmp/Finder";
import Tasks from "./cmp/Tasks";
import Client from "./cmp/Client";

export default {
  name: "App",
  components: { ToolBar, Teasers, Finder, Tasks, Client },
  store: ["Loading", "Employee", "Login"],
  data: () => ({}),
  created() {
    this.Employee = JSON.parse(this.$cookie.get("employee"));
    this.Employee ? this.$store.InitData() : (this.Login.ShowForm = true);
  },
  methods: {
    authenticate() {
      this.Login.Authenticating = true;
      this.$store.Authenticate();
    }
  }
};
</script>

<style>
.rounded {
  border-radius: 7px;
}
.no-underline {
  text-decoration: none;
}

.app {
  border-left: 1px solid rgb(228, 228, 228);
  border-right: 1px solid rgb(228, 228, 228);
}
</style>
