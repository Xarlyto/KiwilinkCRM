<template>
  <v-card class="ma-1">
    <v-layout
      align-center
      class="pl-2"
    >
      <v-item-group v-model="window">
        <v-item
          v-for="n in length"
          :key="n"
        >
          <div slot-scope="{ active, toggle }">
            <v-btn
              :input-value="active"
              icon
              @click="toggle"
            >
              <v-icon>fa-circle</v-icon>
            </v-btn>
          </div>
        </v-item>
      </v-item-group>

      <v-flex class="pa-0">
        <v-window
          v-model="window"
          vertical
        >
          <v-window-item>
            <v-card flat>
              <v-card-text class="pa-2">
                <v-layout
                  align-center
                  class="my-4"
                >
                  <v-avatar color="indigo mx-4">
                    <v-icon dark>fa-user-circle</v-icon>
                  </v-avatar>
                  <strong class="title">Personal Info</strong>
                  <v-spacer></v-spacer>
                </v-layout>

                <p>
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>

              </v-card-text>
            </v-card>
          </v-window-item>

          <v-window-item>
            <v-card flat>
              <v-card-text class="pa-2">
                <v-layout
                  align-center
                  class="my-4"
                >
                  <v-avatar color="indigo mx-4">
                    <v-icon dark>fa-user-circle</v-icon>
                  </v-avatar>
                  <strong class="title">Personal Info</strong>
                  <v-spacer></v-spacer>
                </v-layout>

                <p>
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
                </p>

              </v-card-text>
            </v-card>
          </v-window-item>
        </v-window>
      </v-flex>
    </v-layout>
  </v-card>

</template>

<script>
export default {
  data: () => ({
    length: 4,
    window: 0
  })
};
</script>

<style>
</style>
