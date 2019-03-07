export default {
  Client: null,
  Teasers: [],
  Tasks: [],
  SearchByValue: "Name",
  SearchByList: ["ID", "Name", "Phone", "Country"],
  SearchTerm: "",

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
        Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
      },
      {
        ID: 2,
        Client: "Martha Stewart",
        Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
      },
      {
        ID: 3,
        Client: "Steve Harvey",
        Content: "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Eius, ut. Porro, modi minus vero odit neque, voluptatum quo fuga sint inventore asperiores quis blanditiis architecto mollitia atque rerum? Illum, pariatur.",
      }
    ]


    this.Client = {}
  }
};

