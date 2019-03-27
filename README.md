# KiwilinkCRM
A [C]ustomer [R]elationship [M]anagement app for a Education Consultation Service.
Shows how to do full stack rapid app development with the following technologies.

**Tech Stack**
- Frontend: Vuetify + VueJS + VueStash for state management [no Vuex or Vue Router]
- API Server: ASP.Net Core Web API [no ASP Identity or authentication but simple clear text password checking/storage]
- Data Access: MongoDB using C# Linq queries [with a generic repository]

**Steps to get running**

*Frontend*
1. download/clone this repo
2. open the `Kiwilink-Vue` folder in VSCode.
3. press `CTRL+~` and enter `npm install` (assuming you have nodejs and npm installed).
4. then enter `npm run serve`.

*Database*
1. install mongodb [msi installer is the easiest to get things going if running windows].
2. modify the `Kiwilink-API/Data/mongod.cfg` file to specify your database and log folder.
3. copy the above file to your mongodb `bin` folder and replace the existing one.
4. restart the `mongod` service. [or if not running as a service just run with the above config].

*Visual Studio*
1. download and install Visual Studio + .Net Core SDK.
2. open the solution file `Kiwilink-API/KiwilinkCRM.sln` in VS.
3. click the play/debug button to run the API server.

*Add An Employee*

1. visit `http://localhost:8888/api/add-employee/Tester/testpassword` in a web browser

*Ready*

1. visit `http://localhost:8080`
