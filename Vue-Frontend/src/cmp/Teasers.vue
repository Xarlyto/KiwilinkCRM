<template>
  <div>
    <v-card
      v-for="t in teasers"
      :key="t.ID"
      class="pa-3 ma-1"
    >
      <div class="row">
        <v-icon small>fa-user-circle</v-icon>
        <span>{{ t.Name }}</span>
      </div>
      <div class="row">
        <v-icon small>fa-phone-square</v-icon>
        <span>{{ t.Mobile }}</span>
      </div>
      <div class="row">
        <v-icon small>fa-graduation-cap</v-icon>
        <span>{{ t.Course }}</span>
      </div>
      <div class="row">
        <v-icon small>fa-university</v-icon>
        <span>{{ t.Institute }}</span>
      </div>
      <v-divider></v-divider>
      <v-card-actions class="text-lg-right">
        <v-btn
          small
          flat
          color="orange lighten-2"
        >
          <v-icon>fa-folder-open</v-icon>
          open
        </v-btn>
        <v-btn
          small
          flat
          color="red lighten-2"
        >
          <v-icon>fa-trash-alt</v-icon>
          delete
        </v-btn>
      </v-card-actions>
    </v-card>
    {{"Test: "+test}}
  </div>
</template>

<script>
import State from "../state.js";

export default {
  data() {
    return {
      teasers: [],
      test: ""
    };
  },

  methods: {
    loadClient() {
      alert("load client");
    }
  },

  created() {
    this.teasers = State.Teasers;
    this.test = State.SearchTerm;
  }
};
</script>

<style scoped>
.v-icon {
  width: 40px;
}
.v-card .row {
  height: 25px;
}
</style>
