export default {
  Client: null,
  Teasers: [],
  Tasks: [],
  Task: null,
  SearchByValue: "Name",
  SearchTerm: "",
  Lists: {},

  LoadInitialData() {
    this.Teasers = [
      {
        ID: 1,
        Name: "Damith Ranjan Gunathilake",
        Mobile: "0713429292",
        Course: "Diploma in political sciense",
        Institute: "PBS Institute"
      },
      {
        ID: 2,
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
      },
      {
        ID: 2,
        Client: "Martha Stewart",
        AssignedTo: "Donna",
        Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
      },
      {
        ID: 3,
        Client: "Steve Harvey",
        AssignedTo: "Mra",
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


/*
Address:"kjhkjhkjhjh"
ArrivalDate:"2019-03-04"
Background:"kjhkjhh"
CV:"jkh"
Course:"kj"
CourseCountry:"America"
CourseDuration:"kjkj"
CourseFee:"kj"
CourseIntakeDate:"2019-03-05"
CourseLink:"kjk"
CourseStartDate:"2019-03-05"
CommissionAmount: "jkhjkh"
CommissionDate: "2019-03-05"
Email1:"jh"
Email2:"jkh"
Institute:"jjj"
Landline:"jkh"
LeadSource:"Google"
MinIELTS:"kjh"
Mobile:"jh"
Name:"jhjk"
Passport:"jkh"
PathwayProgram1:"jkj"
PathwayProgram2:"kjkj"
Surname:"jh"
VisaAppliedDate:"2019-03-05"
VisaApprovedDate:"2019-03-05"
VisaStatus:"Applied"
*/

