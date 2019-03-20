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

  },

  OpenClient(cl) {
    cl.Loading = true;
    axios.get(`${this.API}client/load/${cl.Id}`)
      .then(res => {
        this.Client = res.data;
        this.Client.ArrivalDate = this.FormatDate(this.Client.ArrivalDate);
        this.Tasks = res.data.TaskList;
        cl.Loading = false;
      })
  },

  FormatDate(date) {
    if (!date) return '';
    return moment(date).format("YYYY-MM-DD");
  },

  LoadInitialData() {
    this.Teasers = [
      {
        ID: 1,
        Name: "Damith Ranjan Gunathilake",
        Mobile: "0713429292",
        Course: "Diploma in political sciense",
        Institute: "PBS Institute"
      }
    ];

    this.Tasks = [
      {
        ID: 1,
        Client: "Damith Gunathilake",
        AssignedTo: "Danny",
        Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
      }
    ]

    this.Client = {}

    this.Task = {
      ID: 3,
      Client: "Steve Harvey",
      AssignedTo: "Nalin",
      Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
    }

    this.Lists = {
      LeadSource: ["Google", "Facebook", "Newspaper"],
      CourseCountry: ["America", "Australia"],
      Employees: ["Nalin", "Damith", "Sunimalee"]
    }
  }
};