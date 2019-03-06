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
  }
};

