import axios from 'axios';
import moment from 'moment';

export default {
  Client: {},
  Teasers: [],
  Tasks: [],
  Task: {},
  SearchByValue: "Name",
  SearchTerm: "",
  Lists: {},
  API: process.env.VUE_APP_API_URL,
  Loading: true,

  InitData() {
    axios.get(this.API + "home")
      .then(res => {
        this.Teasers = res.data.Teasers;
        this.Tasks = res.data.Tasks;
        this.Loading = false;
      });
  },

  SaveClient() {
    delete this.Client.TaskList;
    axios.post(this.API + "client/save", this.Client)
      .then(res => {
        this.Client.Saving = false;
      }).catch(err => {
        console.log(err.message)
      })
  },

  OpenClient(cl) {
    cl.Loading = true;
    axios.get(`${this.API}client/load/${cl.Id}`)
      .then(res => {
        this.Client = res.data;

        this.Client.ArrivalDate = this.FormatDate(this.Client.ArrivalDate);
        this.Client.CommissionDate = this.FormatDate(this.Client.CommissionDate);
        this.Client.CourseIntakeDate = this.FormatDate(this.Client.CourseIntakeDate);
        this.Client.CourseStartDate = this.FormatDate(this.Client.CourseStartDate);
        this.Client.VisaAppliedDate = this.FormatDate(this.Client.VisaAppliedDate);
        this.Client.VisaApprovedDate = this.FormatDate(this.Client.VisaApprovedDate);

        this.Tasks = res.data.TaskList;
        cl.Loading = false;
      })
  },

  FormatDate(date) {
    if (!date) return '';
    return moment(date).format("YYYY-MM-DD");
  },

  // LoadInitialData() {

  //   this.Task = {
  //     ID: 3,
  //     Client: "Steve Harvey",
  //     AssignedTo: "Nalin",
  //     Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
  //   }

  //   this.Lists = {
  //     LeadSource: ["Google", "Facebook", "Newspaper"],
  //     CourseCountry: ["America", "Australia"],
  //     Employees: ["Nalin", "Damith", "Sunimalee"]
  //   }
  // }
};