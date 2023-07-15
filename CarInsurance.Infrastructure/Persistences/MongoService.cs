using System.Collections.Generic;
using System.Threading.Tasks;
using CarInsurance.Application.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarInsurance.Infrastructure.Persistences
{
    public class MongoService<T> : IPersistenceService<T>
    {
        private readonly IMongoCollection<T> _mongoCollection;

        public MongoService(IOptions<MongoStoreDatabaseSettings> mongoStoreDatabaseSettings, string collectionName)
        {
            var mongoClient = new MongoClient(mongoStoreDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoStoreDatabaseSettings.Value.DatabaseName);
            _mongoCollection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> GetInstanceCollection() { return _mongoCollection; }

        public async Task<List<T>> GetAsync() =>
        await _mongoCollection.Find(_ => true).ToListAsync();

        public async Task<T> GetAsync(string id) =>
            await _mongoCollection.Find(id).FirstOrDefaultAsync();

        public async Task CreateAsync(T newBook) =>
            await _mongoCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, T updatedBook) =>
            await _mongoCollection.ReplaceOneAsync(id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _mongoCollection.DeleteOneAsync(id);
    }
}
