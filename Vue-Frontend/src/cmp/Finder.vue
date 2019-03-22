<template>
  <v-container class="mt-0 py-0">
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
          v-model="SearchTerm"
          label="Search Term"
          append-icon="fa-search"
        ></v-text-field>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
export default {
  data: () => ({
    SearchByList: ["Name", "Passport #", "Phone", "Country"]
  }),
  store: ["SearchByValue", "SearchTerm"],
  methods: {}
};
</script>

<style scoped>
.v-text-field__details {
  display: none;
}
</style>
