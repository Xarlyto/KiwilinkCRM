<template>
  <div>
    <v-card
      v-for="t in Teasers"
      :key="t.Id"
      class="ma-1 pa-3"
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
      <v-card-actions class="text-lg-right pb-0">
        <v-btn
          small
          flat
          color="orange lighten-2"
        >
          <v-icon size="20">fa-folder-open</v-icon>
          open
        </v-btn>
        <v-btn
          small
          flat
          color="red lighten-2"
        >
          <v-icon size="20">fa-trash-alt</v-icon>
          delete
        </v-btn>
      </v-card-actions>
    </v-card>
  </div>
</template>

<script>
export default {
  store: ["Teasers"]
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
