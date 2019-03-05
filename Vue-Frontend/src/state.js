class State {
  constructor() {
    this.Client = null;
    this.Teasers = [];
    this.Tasks = [];
    this.SearchByValue = "Name";
    this.SearchByList = ["ID", "Name", "Phone", "Country"];
    this.SearchTerm = "";

    this.LoadInitialData();
  }

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
}

export default new State();
