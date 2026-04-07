using LogisticsCMS.Settings;
using MongoDB.Driver;

namespace LogisticsCMS.Services
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient mongoClient, DatabaseSettings databaseSettings)
        {
            _database = mongoClient.GetDatabase(databaseSettings.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
