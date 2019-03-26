<template>
  <v-toolbar>
    <v-toolbar-title
      ><span class="display-2 purple darken-4 white--text pa-1">KIWILINK</span
      ><span class="font-weight-black display-1">CRM</span></v-toolbar-title
    >
    <v-spacer></v-spacer>
    <v-toolbar-items v-if="Employee">
      <v-btn flat @click="newClient">
        <v-icon color="purple darken-4" class="mr-2">
          fa-folder-plus
        </v-icon>
        New Client
      </v-btn>
      <v-btn flat>
        <v-icon color="purple darken-4" class="mr-2">
          fa-user-circle
        </v-icon>
        {{ Employee.Name }}
      </v-btn>
      <v-btn flat @click="logOut">
        <v-icon color="purple darken-4" class="mr-2">
          fa-sign-out-alt
        </v-icon>
        Sign Out
      </v-btn>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
export default {
  store: ["Employee"],
  methods: {
    newClient() {
      this.$store.NewClient();
    },
    logOut() {
      this.$store.LogOut();
    }
  }
};
</script>
