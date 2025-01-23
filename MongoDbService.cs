using MongoDB.Driver;
using System.Collections;

namespace PlanMyMeal_Domain
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService()
        {
            var connectionString = "mongodb://rsda230:Kk9pXCEMw9Gyd5Bk@cluster0-shard-00-00.nyfin.mongodb.net:27017,cluster0-shard-00-01.nyfin.mongodb.net:27017,cluster0-shard-00-02.nyfin.mongodb.net:27017/?ssl=true&replicaSet=atlas-qmx7y5-shard-0&authSource=admin&retryWrites=true&w=majority&appName=Cluster0";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("PlanMyMeal");
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
