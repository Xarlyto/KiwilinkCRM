using System;
using System.Linq;
using MongoDB.Driver;
using Pluralize.NET;
using Kiwilink.Models;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace Kiwilink.Data
{
    public static class DB
    {
        private static IMongoDatabase _db;
        private static Pluralizer _plural;

        static DB()
        {
            _db = new MongoClient("mongodb://localhost:27017").GetDatabase("kiwilink");
            _plural = new Pluralizer();
        }

        private static string CollectionName<T>()
        {
            return _plural.Pluralize(typeof(T).Name);
        }

        private static IMongoCollection<T> collection<T>()
        {
            return _db.GetCollection<T>(CollectionName<T>());
        }

        public static IMongoQueryable<T> Collection<T>()
        {
            return collection<T>().AsQueryable();
        }

        public static void Save<T>(T record) where T : Base
        {
            if (record.Id.Equals(ObjectId.Empty)) record.Id = ObjectId.GenerateNewId();

            record.LastEditedOn = DateTime.UtcNow;

            collection<T>().ReplaceOne(
                x => x.Id.Equals(record.Id),
                record,
                new UpdateOptions() { IsUpsert = true });
        }

        public static void Delete<T>(ObjectId id) where T: Base {
            collection<T>().DeleteOne(x => x.Id.Equals(id));
        }       
    }

}
