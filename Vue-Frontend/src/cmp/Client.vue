<template>
  <v-card class="ma-1">

    <v-container>
      <v-layout class="pl-2">
        <v-item-group
          v-model="window"
          class="grey lighten-4 rounded"
        >
          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn
                :input-value="active"
                icon
                @click="toggle"
              >
                <v-icon size="28">fa-user-circle</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn
                :input-value="active"
                icon
                @click="toggle"
              >
                <v-icon size="28">fa-university</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn
                :input-value="active"
                icon
                @click="toggle"
              >
                <v-icon size="28">fa-plane-departure</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn
                :input-value="active"
                icon
                @click="toggle"
              >
                <v-icon size="28">fa-dollar-sign</v-icon>
              </v-btn>
            </div>
          </v-item>
        </v-item-group>

        <v-flex class="pa-3">
          <v-window v-model="window">
            <v-window-item>
              <v-card
                flat
                class="pa-0"
              >
                <v-card-text class="pa-0">
                  <v-layout
                    align-center
                    class="ma-0"
                  >
                    <h1 class="grey--text text--darken-2">Personal Info</h1>
                  </v-layout>
                  <v-layout
                    ml-0
                    py-0
                  >
                    <v-layout
                      row
                      wrap
                    >
                      <v-flex>
                        <v-text-field
                          class="ma-0 pa-0 mt-3"
                          v-model="Client.Name"
                          label="First Names"
                          :readonly="readOnly"
                        ></v-text-field>
                        <v-text-field
                          class="ma-0 pa-0 mt-3"
                          v-model="Client.Mobile"
                          label="Mobile"
                          :readonly="readOnly"
                        ></v-text-field>
                      </v-flex>
                      <v-flex>
                        <v-text-field
                          class="ma-0 pa-0 mt-3"
                          v-model="Client.Surname"
                          label="Surname"
                          :readonly="readOnly"
                        ></v-text-field>
                        <v-text-field
                          class="ma-0 pa-0 mt-3"
                          v-model="Client.Landline"
                          label="Land Line"
                          :readonly="readOnly"
                        ></v-text-field>
                      </v-flex>
                    </v-layout>
                  </v-layout>
                </v-card-text>

                <v-card-actions class="text-lg-right pt-2">
                  <v-btn
                    small
                    flat
                    color="orange lighten-2"
                    @click="readOnly= !readOnly"
                    v-if="readOnly"
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
                    v-if="!readOnly"
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
                  >
                    <v-icon
                      class="mr-2"
                      size="20"
                    >fa-trash-alt</v-icon>
                    delete
                  </v-btn>
                </v-card-actions>

              </v-card>
            </v-window-item>

          </v-window>
        </v-flex>

      </v-layout>
    </v-container>
  </v-card>

</template>

<script>
export default {
  data: () => ({
    window: 0,
    readOnly: true
  }),

  store: ["Client"]
};
</script>

<style>
</style>
