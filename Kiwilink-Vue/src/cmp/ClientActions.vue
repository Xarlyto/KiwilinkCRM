<template>
  <v-card-actions class="text-lg-right pt-2">
    <v-btn
      small
      flat
      color="orange lighten-2"
      @click="Client.ReadOnly = !Client.ReadOnly"
      v-if="Client.ReadOnly"
    >
      <v-icon size="20" class="mr-2">fa-edit</v-icon>
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
      <v-icon size="20" class="mr-2">fa-save</v-icon>
      save
    </v-btn>

    <v-btn
      small
      flat
      color="blue lighten-2"
      v-if="ShowTaskAddBtn"
      @click="addTask"
    >
      <v-icon class="mr-2" size="20">fa-calendar-plus</v-icon>
      new task
    </v-btn>
    <v-btn small flat color="brown lighten-2" @click="closeClient">
      <v-icon class="mr-2" size="20">fa-times-circle</v-icon>
      close
    </v-btn>

    <v-spacer></v-spacer>
    <v-btn
      small
      flat
      color="red lighten-2"
      v-if="enableDelete"
      @click="deleteClient"
    >
      <v-icon size="20">fa-trash-alt</v-icon>
    </v-btn>
  </v-card-actions>
</template>

<script>
export default {
  store: ["Client", "CurrentWindow", "ShowTaskAddBtn", "Task", "Employee"],
  methods: {
    saveClient() {
      if (this.Client.Pathways) {
        this.Client.Pathways = this.Client.Pathways.filter(
          p => p.Name !== "" && p.Link !== ""
        );
      }

      if (this.Client.Commissions) {
        this.Client.Commissions = this.Client.Commissions.filter(
          c => c.Ammount !== "" && c.Date !== ""
        );
      }

      this.Client.Saving = true;
      this.$store.SaveClient();
    },
    closeClient() {
      this.$store.CloseClient();
    },
    deleteClient() {
      this.$confirm("Are you sure you want to delete?").then(yes => {
        if (yes) {
          this.$store.DeleteClient(this.Client.Id);
        }
      });
    },
    addTask() {
      this.$store.OpenTask({
        Id: "",
        ClientId: this.Client.Id,
        ClientName: this.Client.Name + " " + this.Client.Surname
      });
    }
  },
  computed: {
    enableDelete() {
      return (
        !this.Client.ReadOnly &&
        this.Client.DeleteEnable &&
        this.Employee.IsAdmin
      );
    }
  }
};
</script>

<style></style>
