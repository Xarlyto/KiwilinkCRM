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
  CurrentWindow: 0,

  InitData() {
    axios.get(this.API + "home")
      .then(res => {
        this.Teasers = res.data.Teasers;
        this.Tasks = res.data.Tasks;
        this.Lists = res.data.Lists;
        this.Loading = false;
      });
  },

  SaveClient() {
    //combobox issue needs delayed submit
    setTimeout(() => {
      delete this.Client.TaskList;
      axios.post(this.API + "client/save", this.Client)
        .then(res => {
          this.Client.Saving = false;

          var teaser = this.Teasers.find(t => t.Id == this.Client.Id);
          teaser.Name = this.Client.Name + " " + this.Client.Surname;
          teaser.Mobile = this.Client.Mobile;
          teaser.Course = this.Client.Course;
          teaser.Institute = this.Client.Institute;

          this.Teasers.splice(this.Teasers.indexOf(teaser), 1);
          this.Teasers.unshift(teaser);

        }).catch(err => {
          if (err.response) {
            console.log(err.response.data);
            if (err.response.data.title == "One or more validation errors occurred.") {
              alert("Cannot save client info without first and last names!!!")
            }
            this.Client.Saving = false;
          }
          else {
            console.log(err);
          }
        })
    }, 300);

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
};