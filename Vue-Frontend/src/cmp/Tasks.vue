<template>
  <v-container class="mt-0 pt-0">
    <h1>Tasks</h1>
    <v-card
      v-for="t in Tasks"
      :key="t.ID"
      class="mb-2"
    >
      <v-card-title class="pa-2 blue darken-3 white--text">
        {{t.Client}}
      </v-card-title>
      <v-card-text class="pb-0">
        {{t.Content}}
      </v-card-text>
      <v-card-actions class="pt-0">
        <v-spacer></v-spacer>
        <v-btn
          fab
          small
          dark
          flat
          color="orange lighten-1"
        >
          <v-icon>fa-edit</v-icon>
        </v-btn>
        <v-btn
          fab
          small
          dark
          flat
          color="green darken-3"
        >
          <v-icon>fa-check</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script>
export default {
  store: ["Tasks"]
};
</script>

<style scoped>
.v-card {
  border-radius: 7px !important;
}
</style>
