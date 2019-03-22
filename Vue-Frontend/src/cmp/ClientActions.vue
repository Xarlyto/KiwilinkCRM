<template>
  <v-card-actions class="text-lg-right pt-2">
    <v-btn
      small
      flat
      color="orange lighten-2"
      @click="Client.ReadOnly = !Client.ReadOnly"
      v-if="Client.ReadOnly"
    >
      <v-icon
        size="20"
        class="mr-2"
      >fa-edit</v-icon>
      edit
    </v-btn>
    <v-btn
      small
      flat
      color="orange lighten-2"
      v-if="!Client.ReadOnly"
      @click="saveClient"
      :loading="Client.Saving"
    >
      <v-icon
        size="20"
        class="mr-2"
      >fa-save</v-icon>
      save
    </v-btn>
    <v-btn
      small
      flat
      color="red lighten-2"
      v-if="!Client.ReadOnly"
    >
      <v-icon
        class="mr-2"
        size="20"
      >fa-trash-alt</v-icon>
      delete
    </v-btn>
    <v-btn
      small
      flat
      color="blue lighten-2"
      v-if="ShowTaskAddBtn"
    >
      <v-icon
        class="mr-2"
        size="20"
      >fa-calendar-plus</v-icon>
      new task
    </v-btn>
    <v-btn
      small
      flat
      color="brown lighten-2"
      @click="closeClient"
    >
      <v-icon
        class="mr-2"
        size="20"
      >fa-times-circle</v-icon>
      close
    </v-btn>
  </v-card-actions>
</template>

<script>
export default {
  store: ["Client", "CurrentWindow", "ShowTaskAddBtn"],
  methods: {
    saveClient() {
      this.Client.Saving = true;
      this.$store.SaveClient();
    },
    closeClient() {
      this.$store.CloseClient();
    }
  }
};
</script>

<style>
</style>
