using MongoDB.Driver;

namespace LogisticsCMS.Services
{
    public interface IMongoDbContext
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
