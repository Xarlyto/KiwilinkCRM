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

export default {
  name: "App",
  components: { ToolBar, Teasers, Finder, Tasks },
  created() {
    this.$store.LoadInitialData();
  }
};
</script>
