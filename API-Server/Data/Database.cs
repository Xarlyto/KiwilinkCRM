using API_Server.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Server.Data
{
    public static class Database
    {
        private static IMongoCollection<Client> Clients { get; set; }
        private static IMongoCollection<Models.Task> Tasks { get; set; }
        private static IMongoCollection<Employee> Employees { get; set; }

        static Database()
        {
            var mongo = new MongoClient("mongodb://localhost:27017").GetDatabase("kiwilink");

            Clients = mongo.GetCollection<Client>("Clients");
            Tasks = mongo.GetCollection<Models.Task>("Tasks");
            Employees = mongo.GetCollection<Employee>("Employees");

            System.Diagnostics.Debug.WriteLine("MongoDB Initialized...");
        }

        public static ObjectId SaveClient(Client client)
        {
            if (client.Id == ObjectId.Empty) client.Id = ObjectId.GenerateNewId();

            Clients.ReplaceOne<Client>(
                c => c.Id.Equals(client.Id),
                client,
                new UpdateOptions { IsUpsert = true});

            return client.Id;
        }

        public static Client FindClient(ObjectId Id)
        {
            return (from c in Clients.AsQueryable()
                    where c.Id.Equals(Id)
                    select c).SingleOrDefault();
        }

    }
}
