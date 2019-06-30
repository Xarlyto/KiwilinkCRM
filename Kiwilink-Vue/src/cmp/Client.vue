<template>
  <v-card v-if="Object.keys(Client).length > 0" class="ma-1">
    <v-container>
      <v-layout class="pl-2">
        <v-item-group v-model="CurrentWindow" class="grey lighten-4 rounded">
          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn :input-value="active" icon @click="toggle" large>
                <v-icon size="28">fa-user-circle</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn :input-value="active" icon @click="toggle" large>
                <v-icon size="27">fa-graduation-cap</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn :input-value="active" icon @click="toggle" large>
                <v-icon size="24">fa-plane-departure</v-icon>
              </v-btn>
            </div>
          </v-item>

          <v-item>
            <div slot-scope="{ active, toggle }">
              <v-btn
                :input-value="active"
                icon
                @click="toggle"
                large
                v-if="Employee.IsAdmin"
              >
                <v-icon size="28">fa-dollar-sign</v-icon>
              </v-btn>
            </div>
          </v-item>
        </v-item-group>

        <v-flex class="pa-3">
          <v-window v-model="CurrentWindow">
            <v-window-item>
              <v-card flat class="pa-0">
                <v-card-text class="pa-0">
                  <v-layout align-center class="ma-0">
                    <h1 class="grey--text text--darken-2">Personal Info</h1>
                  </v-layout>

                  <v-layout row wrap mx-4>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Name"
                      label="First Names"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Surname"
                      label="Surname"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Mobile"
                      label="Mobile"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Landline"
                      label="Land Line"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Email1"
                      label="Email Address 1"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Email2"
                      label="Email Address 2"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-combobox
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.LeadSource"
                      :items="Lists.LeadSources"
                      label="Lead Source"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-combobox>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Passport"
                      label="Passport #"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                  </v-layout>

                  <v-layout column mx-3>
                    <v-flex xs12>
                      <v-textarea
                        name="Address"
                        label="Postal Address"
                        v-model="Client.Address"
                        class="ma-0 pa-0 mt-3 mr-3"
                        :readonly="Client.ReadOnly"
                        :background-color="formColor"
                      ></v-textarea>
                    </v-flex>
                    <v-flex xs12>
                      <v-textarea
                        name="Education"
                        label="Education History"
                        v-model="Client.Education"
                        class="ma-0 pa-0 mt-3 mr-3"
                        :readonly="Client.ReadOnly"
                        :background-color="formColor"
                      ></v-textarea>
                    </v-flex>
                    <v-flex xs12>
                      <v-textarea
                        name="Work"
                        label="Work Experience"
                        v-model="Client.Work"
                        class="ma-0 pa-0 mt-3 mr-3"
                        :readonly="Client.ReadOnly"
                        :background-color="formColor"
                      ></v-textarea>
                    </v-flex>
                    <v-flex xs12>
                      <v-text-field
                        class="ma-0 pa-0 mt-3 mr-3"
                        v-model="Client.CV"
                        label="CV Link"
                        :readonly="Client.ReadOnly"
                        :background-color="formColor"
                      ></v-text-field>
                    </v-flex>
                  </v-layout>
                </v-card-text>

                <client-actions />
              </v-card>
            </v-window-item>

            <v-window-item>
              <v-card flat class="pa-0">
                <v-card-text class="pa-0">
                  <v-layout align-center class="ma-0">
                    <h1 class="grey--text text--darken-2">Course Info</h1>
                  </v-layout>

                  <v-layout row wrap mx-4>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Course"
                      label="Course Name"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-combobox
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.CourseCountry"
                      :items="Lists.CourseCountries"
                      label="Course Country"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-combobox>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.MinIELTS"
                      label="Min. IELTS"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-combobox
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.Institute"
                      :items="Lists.Institutes"
                      label="Institute"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-combobox>
                    <v-menu
                      class="mr-3"
                      v-model="showStartDate"
                      :disabled="Client.ReadOnly"
                      :close-on-content-click="false"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="Client.CourseStartDate"
                          label="Start Date"
                          readonly
                          v-on="on"
                          :background-color="formColor"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="Client.CourseStartDate"
                        @input="showStartDate = false"
                      ></v-date-picker>
                    </v-menu>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.CourseDuration"
                      label="Course Duration"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.CourseFee"
                      label="Course Fee"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.CourseLink"
                      label="Course Website Link"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                  </v-layout>

                  <v-layout align-center class="ma-0">
                    <h1 class="grey--text text--darken-2">Pathway Programs</h1>
                    <v-btn flat icon color="indigo" small @click="addPathway">
                      <v-icon size="16">fa-plus</v-icon>
                    </v-btn>
                  </v-layout>
                  <v-card
                    v-if="Client.Pathways ? Client.Pathways.length == 0 : true"
                    flat
                    fab
                    class="grey lighten-5 pa-0 ma-0 grey--text"
                  >
                    <v-card-text>
                      Click + button above to add a pathway program...
                    </v-card-text>
                  </v-card>
                  <v-layout
                    row
                    wrap
                    mx-4
                    v-for="(pp, i) in Client.Pathways"
                    :key="i"
                  >
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="pp.Name"
                      label="Program Name"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="pp.Link"
                      label="Program Link"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>
                  </v-layout>
                </v-card-text>
                <client-actions />
              </v-card>
            </v-window-item>

            <v-window-item>
              <v-card flat class="pa-0">
                <v-card-text class="pa-0">
                  <v-layout align-center class="ma-0">
                    <h1 class="grey--text text--darken-2">Visa Info</h1>
                  </v-layout>

                  <v-layout row wrap mx-4>
                    <v-combobox
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="Client.VisaStatus"
                      :items="visaStatusList"
                      label="Visa Status"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-combobox>
                    <v-menu
                      class="mr-3"
                      v-model="showAppliedDate"
                      :disabled="Client.ReadOnly"
                      :close-on-content-click="false"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="Client.VisaAppliedDate"
                          label="Applied Date"
                          readonly
                          v-on="on"
                          :background-color="formColor"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="Client.VisaAppliedDate"
                        @input="showAppliedDate = false"
                      ></v-date-picker>
                    </v-menu>

                    <v-menu
                      class="mr-3"
                      v-model="showApprovedDate"
                      :disabled="Client.ReadOnly"
                      :close-on-content-click="false"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="Client.VisaApprovedDate"
                          label="Approved Date"
                          readonly
                          v-on="on"
                          :background-color="formColor"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="Client.VisaApprovedDate"
                        @input="showApprovedDate = false"
                      ></v-date-picker>
                    </v-menu>

                    <v-menu
                      class="mr-3"
                      v-model="showArrivalDate"
                      :disabled="Client.ReadOnly"
                      :close-on-content-click="false"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="Client.ArrivalDate"
                          label="Arrival Date"
                          readonly
                          v-on="on"
                          :background-color="formColor"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="Client.ArrivalDate"
                        @input="showArrivalDate = false"
                      ></v-date-picker>
                    </v-menu>
                  </v-layout>
                </v-card-text>

                <client-actions />
              </v-card>
            </v-window-item>

            <v-window-item>
              <v-card flat class="pa-0">
                <v-card-text class="pa-0">
                  <v-layout align-center class="ma-0">
                    <h1 class="grey--text text--darken-2">Commission Info</h1>
                    <v-btn
                      flat
                      icon
                      color="indigo"
                      small
                      @click="addCommission"
                    >
                      <v-icon size="16">fa-plus</v-icon>
                    </v-btn>
                  </v-layout>
                  <v-card
                    v-if="
                      Client.Commissions ? Client.Commissions.length == 0 : true
                    "
                    flat
                    fab
                    class="grey lighten-5 pa-0 ma-0 grey--text"
                  >
                    <v-card-text>
                      Click + button above to add a commission...
                    </v-card-text>
                  </v-card>
                  <v-layout
                    row
                    wrap
                    mx-4
                    v-for="(c, i) in Client.Commissions"
                    :key="i"
                  >
                    <v-text-field
                      class="ma-0 pa-0 mt-3 mr-3"
                      v-model="c.Amount"
                      label="Amount"
                      :readonly="Client.ReadOnly"
                      :background-color="formColor"
                    ></v-text-field>

                    <v-menu
                      class="mr-3"
                      v-model="c.ShowPicker"
                      :disabled="Client.ReadOnly"
                      :close-on-content-click="false"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="c.Date"
                          label="Received Date"
                          v-on="on"
                          :background-color="formColor"
                        ></v-text-field>
                      </template>
                      <v-date-picker
                        v-model="c.Date"
                        @input="c.ShowPicker = false"
                      ></v-date-picker>
                    </v-menu>
                  </v-layout>
                </v-card-text>

                <client-actions />
              </v-card>
            </v-window-item>
          </v-window>
        </v-flex>
      </v-layout>
    </v-container>
  </v-card>
</template>

<script>
import ClientActions from "./ClientActions";

export default {
  components: { ClientActions },
  data: () => ({
    showStartDate: false,
    showAppliedDate: false,
    showApprovedDate: false,
    showArrivalDate: false,
    visaStatusList: [
      "Not Applied",
      "Docs Collected From Client",
      "Docs Submitted To Institute",
      "Offer Letter Issued",
      "Visa Applied",
      "Visa Pending",
      "Visa Approved"
    ]
  }),

  store: ["Client", "Lists", "CurrentWindow", "Employee"],

  methods: {
    addPathway() {
      if (!this.Client.Pathways) {
        this.Client.Pathways = [];
      }
      this.Client.Pathways.push({ Name: "", Link: "" });
    },
    addCommission() {
      if (!this.Client.Commissions) {
        this.Client.Commissions = [];
      }
      this.Client.Commissions.push({
        Amount: "",
        Date: "",
        ShowPicker: false
      });
    }
  },

  computed: {
    formColor() {
      if (this.Client.ReadOnly) {
        return "";
      }
      return "purple lighten-5";
    }
  }
};
</script>

<style></style>
