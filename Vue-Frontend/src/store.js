import axios from 'axios';
import moment from 'moment';

export default {
  Client: {},
  Teasers: [],
  Tasks: [],
  TasksBackup: [],
  Task: {},
  SearchByValue: "Name",
  SearchTerm: "",
  Lists: {},
  API: process.env.VUE_APP_API_URL,
  Loading: true,
  CurrentWindow: 0,
  ShowTaskAddBtn: true,
  ShowTaskEditor: false,

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
      var client = JSON.parse(JSON.stringify(this.Client))
      delete client.TaskList;

      axios.post(this.API + "client/save", client)
        .then(res => {

          this.Client.Id = res.data;
          this.ShowTaskAddBtn = true;
          var teaser = this.Teasers.find(t => t.Id == this.Client.Id);

          if (!teaser) {
            teaser = { Id: this.Client.Id };
          }

          teaser.Name = this.Client.Name + " " + this.Client.Surname;
          teaser.Mobile = this.Client.Mobile;
          teaser.Course = this.Client.Course;
          teaser.Institute = this.Client.Institute;

          this.Teasers.splice(this.Teasers.indexOf(teaser), 1);
          this.Teasers.unshift(teaser);

          this.Client.Saving = false;
          this.Client.ReadOnly = true;
          this.Client.DeleteEnable = true;

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

  SaveTask() {
    if (!this.Task.Content || !this.Task.AssignedEmployeeName) {
      alert("Please fill up all the fields before saving!")
      this.Task.Saving = false;
    } else {
      axios.post(this.API + "task/save", this.Task)
        .then(res => {
          var isNew = (this.Task.Id == "");
          this.Task.Id = res.data;
          if (isNew) {
            this.Tasks.unshift(this.Task);
            this.TasksBackup.unshift(this.Task);
          }

          this.ShowTaskEditor = false;
          this.Task.Saving = false;
          this.Task = {};
        })
        .catch(err => {
          console.log(err);
        })
    }
  },

  NewClient() {
    this.Client = {
      Id: '',
      ReadOnly: false,
      DeleteEnable: false,
      TaskList: [],
    };
    this.Tasks = [];
    this.ShowTaskAddBtn = false;
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

        this.TasksBackup = this.Tasks;
        this.Tasks = res.data.TaskList;
        cl.Loading = false;
        this.ShowTaskAddBtn = true;
        this.Client.DeleteEnable = true;
      })
  },

  CloseClient() {
    this.Client = {};
    this.CurrentWindow = 0;
    this.Tasks = this.TasksBackup;
  },

  FormatDate(date) {
    if (!date) return '';
    return moment(date).format("YYYY-MM-DD");
  },

  OpenTask(tsk) {
    this.Task = tsk;
    this.ShowTaskEditor = true;
  }
};