<template>
  <v-container>
    <v-layout
      row
      wrap
    >
      <v-flex sm4>
        <v-select
          dense
          hide-selected
          :items='["ID","Name"]'
          label="Search By"
        ></v-select>
      </v-flex>
      <v-flex sm8>
        <v-text-field
          label="Search Term"
          append-icon="fa-search"
        ></v-text-field>
      </v-flex>

    </v-layout>
  </v-container>
</template>

<script>
export default {};
</script>

<style scoped>
.v-text-field__details {
  display: none;
}
</style>
