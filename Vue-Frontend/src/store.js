import axios from 'axios';

export default {
  Client: null,
  Teasers: [],
  Tasks: [],
  Task: null,
  SearchByValue: "Name",
  SearchTerm: "",
  Lists: {},
  API: process.env.API_URL,

  InitData() {

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

    this.Client = null

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