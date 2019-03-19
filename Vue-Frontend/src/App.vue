<template>
  <v-app>
    <v-content>
      <tool-bar />
      <v-container grid-list-lg>
        <v-layout
          row
          wrap
        >
          <v-flex
            xs12
            md8
          >
            <client v-if="Client" />
            <teasers />
          </v-flex>
          <v-flex
            xs12
            md4
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
  store: ["Client"],
  created() {
    this.$store.LoadInitialData();
  }
};
</script>

<style>
.rounded {
  border-radius: 7px;
}
</style>

