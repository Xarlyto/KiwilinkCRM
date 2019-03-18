using System;
using System.Linq;
using MongoDB.Driver;
using Pluralize.NET;
using API_Server.Models;
using MongoDB.Bson;

namespace API_Server.Data
{
    public static class Database
    {
        private static IMongoDatabase _db;
        private static Pluralizer _plural;

        static Database()
        {
            _db = new MongoClient("mongodb://localhost:27017").GetDatabase("kiwilink");
            _plural = new Pluralizer();
        }

        private static string CollectionName<T>()
        {
            return _plural.Pluralize(typeof(T).Name);
        }

        private static IMongoCollection<T> Collection<T>()
        {
            return _db.GetCollection<T>(CollectionName<T>());
        }

        public static IQueryable<T> Queryable<T>()
        {
            return Collection<T>().AsQueryable<T>();
        }

        public static void Save<T>(T record) where T : Base
        {
            if (record.Id.Equals(ObjectId.Empty)) record.Id = ObjectId.GenerateNewId();

            Collection<T>().ReplaceOne<T>(
                x => x.Id.Equals(record.Id),
                record,
                new UpdateOptions() { IsUpsert = true });
        }

        public static void Delete<T>(ObjectId id) where T: Base {
            Collection<T>().DeleteOne<T>(x => x.Id.Equals(id));
        }
    }

}
