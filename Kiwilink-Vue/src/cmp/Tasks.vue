<template>
  <v-container class="mt-0 pt-0">
    <v-layout row wrap>
      <v-flex xs6 sm8 md6 lg8>
        <h1 class="tasks-header">Tasks</h1>
      </v-flex>
      <v-flex xs3 sm2 md3 lg2>
        <v-switch
          v-model="TaskFilters.onlyMe"
          label="Me"
          hide-details
          @change="fetchTasks"
          :loading="TaskFilters.FetchingTasks"
        ></v-switch>
      </v-flex>
      <v-flex xs3 sm2 md3 lg2>
        <v-switch
          v-model="TaskFilters.showAll"
          hide-details
          label="All"
          @change="fetchTasks"
          :loading="TaskFilters.FetchingTasks"
        ></v-switch>
      </v-flex>
    </v-layout>
    <v-card v-if="Tasks.length == 0" flat>
      <v-card-text>
        <span class="grey--text darken-1">No tasks to display...</span>
      </v-card-text>
    </v-card>
    <v-card v-for="t in Tasks" :key="t.Id" class="mb-2">
      <v-card-title
        :class="`pa-2 ${t.IsComplete ? 'green' : 'blue'} darken-3 white--text`"
      >
        <a
          href="#"
          class="white--text no-underline"
          @click.prevent="openClient(t)"
          >{{ t.ClientName }}</a
        >
        <v-progress-circular
          indeterminate
          size="17"
          width="2"
          color="white"
          class="ml-1"
          v-if="t.OpeningClient"
        ></v-progress-circular>
      </v-card-title>
      <v-card-text class="pb-0">
        {{ t.Content }}
      </v-card-text>
      <v-card-actions class="pt-0">
        <span class="grey--text caption ml-2"
          >Assigned To: <b>{{ t.AssignedEmployeeName }}</b></span
        >
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
          v-if="!t.IsComplete"
        >
          <v-icon>fa-check</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>

    <v-dialog v-model="ShowTaskEditor" max-width="400px">
      <v-card>
        <v-card-title class="pa-2 blue darken-3 white--text">
          Client:&nbsp;{{ Task.ClientName }}
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
  data: () => ({}),
  store: [
    "Tasks",
    "Task",
    "Lists",
    "ShowTaskEditor",
    "FetchingTasks",
    "TaskFilters"
  ],
  methods: {
    editTask(task) {
      this.$store.OpenTask(task);
    },
    saveTask() {
      this.Task.Saving = true;
      this.Task.IsComplete = false;
      this.$store.SaveTask();
    },
    completeTask(task) {
      task.Completing = true;
      this.$store.CompleteTask(task.Id);
    },
    openClient(task) {
      task.OpeningClient = true;
      this.$store.OpenClient({ Id: task.ClientId }, task);
    },
    fetchTasks() {
      this.$store.FetchTasks();
    }
  }
};
</script>

<style scoped>
.v-card {
  border-radius: 7px !important;
}

.v-input--switch {
  margin-top: 5px;
}
</style>
