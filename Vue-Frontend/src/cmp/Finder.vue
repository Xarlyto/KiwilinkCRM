<template>
  <v-container>
    <v-layout
      row
      wrap
    >
      <v-flex sm4>
        <v-select
          dense
          v-model="SearchByValue"
          :items="SearchByList"
          label="Search By"
        ></v-select>
      </v-flex>
      <v-flex sm8>
        <v-text-field
          v-model="searchTerm"
          label="Search Term"
          append-icon="fa-search"
        ></v-text-field>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import State from "../state.js";

export default {
  data() {
    return {
      SearchByValue: "",
      SearchByList: [],
      searchTerm: ""
    };
  },
  created() {
    this.SearchByValue = State.SearchByValue;
    this.SearchByList = State.SearchByList;
  }
};
</script>

<style scoped>
.v-text-field__details {
  display: none;
}
</style>
