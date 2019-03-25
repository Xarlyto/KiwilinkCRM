import axios from 'axios';
import moment from 'moment';
import Vue from 'vue';

export default {
  Employee: null,
  Login: {
    ShowForm: false,
    Authenticating: false,
    Username: '',
    Password: ''
  },
  Client: {},
  Teasers: [],
  Tasks: [],
  TaskFilters: {
    onlyMe: true,
    showAll: false,
    FetchingTasks: false
  },
  Task: {},
  SearchByValue: "Name",
  SearchTerm: "",
  Lists: {},
  API: process.env.VUE_APP_API_URL,
  Loading: true,
  CurrentWindow: 0,
  ShowTaskAddBtn: true,
  ShowTaskEditor: false,

  Authenticate() {
    axios.post(this.API + "employee/authenticate",
      {
        Username: this.Login.Username,
        Password: this.Login.Password
      })
      .then(res => {
        Vue.cookie.set("employee", JSON.stringify(res.data), 1);
        this.Employee = res.data;
        this.Login.ShowForm = false;
        this.Authenticating = false;
        this.InitData();
        this.Login.Password = '';
      })
      .catch(err => {
        this.Login.Authenticating = false;
        alert("Sorry! Login unsuccessful...")
      })
  },

  LogOut() {
    this.Employee = null;
    Vue.cookie.delete("employee");
    this.Login.ShowForm = true;
    this.Login.Authenticating = false;
  },

  InitData() {
    axios.get(`${this.API}init/${this.Employee.Name}`)
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

          if (client.Id != '') this.Teasers.splice(this.Teasers.indexOf(teaser), 1);
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

          if (!isNew) {
            var mTask = this.Tasks.find(t => t.Id == this.Task.Id);
            if (mTask) mTask = this.Task;

          } else {
            this.Tasks.unshift(this.Task);
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

  CompleteTask(id) {
    axios.get(`${this.API}task/complete/${id}`)
      .then(res => {
        var t = this.Tasks.find(t => t.Id == id);
        this.Tasks.splice(this.Tasks.indexOf(t), 1);
      })
      .catch(err => {
        console.log(err);
      })
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

  OpenClient(cl, tsk) {
    cl.Loading = true;
    var employee = this.TaskFilters.onlyMe ? this.Employee.Name : 'null';

    axios.get(`${this.API}client/load/${cl.Id}/${employee}/${this.TaskFilters.showAll}`)
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
        if (tsk) tsk.OpeningClient = false;
        this.ShowTaskAddBtn = true;
        this.Client.DeleteEnable = true;
      })
  },

  CloseClient() {
    this.Client = {};
    this.CurrentWindow = 0;
    this.FetchTasks();
  },

  FormatDate(date) {
    if (!date) return '';
    return moment(date).format("YYYY-MM-DD");
  },

  OpenTask(tsk) {
    this.Task = tsk;
    this.ShowTaskEditor = true;
  },

  FetchTasks() {
    this.TaskFilters.FetchingTasks = true;
    var employee = this.TaskFilters.onlyMe ? this.Employee.Name : 'null';
    var clientID = Object.keys(this.Client).length > 0 ? this.Client.Id : 'null'

    axios.get(`${this.API}tasks/fetch/${employee}/${this.TaskFilters.showAll}/${clientID}`)
      .then(res => {
        this.Tasks = res.data;
        this.TaskFilters.FetchingTasks = false;
      })
      .catch(err => {
        console.log(err);
      })
  },

  Search() {
    this.Teasers = [];
    this.Loading = true;
    this.CloseClient();
    var searchTerm = this.SearchTerm ? this.SearchTerm : 'null';
    axios.get(`${this.API}search/${searchTerm}/${this.SearchByValue}`)
      .then(res => {
        this.Teasers = res.data;
        this.Loading = false;
      })
      .catch(err => {
        console.log(err);
      })
  }
};