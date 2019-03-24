<template>
  <v-container class="mt-0 pt-0">
    <h1>Tasks</h1>
    <v-card
      v-if="Tasks.length==0"
      flat
    >
      <v-card-text>
        <span class="grey--text darken-1">No tasks to display...</span>
      </v-card-text>
    </v-card>
    <v-card
      v-for="t in Tasks"
      :key="t.Id"
      class="mb-2"
    >
      <v-card-title class="pa-2 blue darken-3 white--text">
        <a
          href="#"
          class="white--text no-underline"
          @click.prevent="openClient(t.ClientId)"
        >{{t.ClientName}}</a>
      </v-card-title>
      <v-card-text class="pb-0">
        {{t.Content}}
      </v-card-text>
      <v-card-actions class="pt-0">
        <span class="grey--text caption ml-2">Assigned To: <b>{{t.AssignedEmployeeName}}</b></span>
        <v-spacer></v-spacer>
        <v-btn
          fab
          small
          dark
          flat
          color="orange lighten-1"
          @click="editTask(t)"
        >
          <v-icon>fa-edit</v-icon>
        </v-btn>
        <v-btn
          fab
          small
          dark
          flat
          color="green darken-3"
          @click="completeTask(t)"
          :loading="t.Completing"
        >
          <v-icon>fa-check</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>

    <v-dialog
      v-model="ShowTaskEditor"
      max-width="400px"
    >
      <v-card>
        <v-card-title class="pa-2 blue darken-3 white--text">
          Client:&nbsp;{{Task.ClientName}}
        </v-card-title>
        <v-card-text class="pb-0">
          <v-textarea
            name="TaskDetails"
            label="Details"
            v-model="Task.Content"
            class="ma-0 pa-0 mt-3 mr-3"
          ></v-textarea>
          <v-select
            class="ma-0 pa-0 mt-3 mr-3"
            v-model="Task.AssignedEmployeeName"
            :items="Lists.Employees"
            label="Assign To"
          ></v-select>
        </v-card-text>
        <v-card-actions>

          <v-btn
            small
            dark
            flat
            @click="saveTask"
            :loading="Task.Saving"
            color="green darken-3"
          >
            <v-icon class="mr-2">fa-save</v-icon> SAVE
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
export default {
  store: ["Tasks", "Task", "Lists", "ShowTaskEditor"],
  methods: {
    editTask(task) {
      this.$store.OpenTask(task);
    },
    saveTask() {
      this.Task.Saving = true;
      this.$store.SaveTask();
    },
    completeTask(task) {
      task.Completing = true;
      this.$store.CompleteTask(task.Id);
    },
    openClient(cid) {
      this.$store.OpenClient({ Id: cid });
    }
  }
};
</script>

<style scoped>
.v-card {
  border-radius: 7px !important;
}
</style>
