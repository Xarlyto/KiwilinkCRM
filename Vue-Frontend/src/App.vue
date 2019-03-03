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
            left
          </v-flex>
          <v-flex
            xs12
            md4
          >
            right
          </v-flex>
        </v-layout>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import State from "./state.js";
import ToolBar from "./cmp/ToolBar";

export default {
  name: "App",
  components: { ToolBar },
  data() {
    return {};
  },
  created() {}
};
</script>
