using CommonCore.Interfaces.Repository;
using CommonCore.Models.Repo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Repo.MongoDb
{
    public class MongoDbCrudRepository<T> : ICrudRepository<T>
    {
        private readonly MongoUrl _url;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDbCrudRepository(string connectionString)
        {
            _url = new MongoUrl(connectionString);
            _client = new MongoClient(_url);
            _database = _client.GetDatabase(_url.DatabaseName);
        }

        private IMongoCollection<T> GetCollection<T>()
            => _database.GetCollection<T>(typeof(T).Name);

        public async Task Create(T item)
        {
            var collection = GetCollection<T>();
            await collection.InsertOneAsync(item);
        }

        public async Task Create(IEnumerable<T> items)
        {
            var collection = GetCollection<T>();
            await collection.InsertManyAsync(items);
        }

        public async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> filter)
        {
            var collection = GetCollection<T>();
            var cursor = await collection.FindAsync<T>(filter);
            return cursor.ToEnumerable<T>();
        }

        public async Task<IEnumerable<T>> Read(SearchRequest<T> searchRequest)
        {
            var collection = GetCollection<T>();
            var cursor = await collection.FindAsync<T>(searchRequest.Filter, new FindOptions<T>()
            {
                Limit = searchRequest.Limit,
                Skip = searchRequest.Skip
            });
            return cursor.ToEnumerable<T>();
        }

        public async Task<(bool, T)> Update(T item, Expression<Func<T, bool>> filter)
        {
            var collection = GetCollection<T>();
            var updateResult = await collection.ReplaceOneAsync<T>(filter, item);
            return (updateResult.IsAcknowledged, item);
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            var collection = GetCollection<T>();
            var deleteResult = await collection.DeleteOneAsync<T>(expression);
            return deleteResult.IsAcknowledged;
        }

        public async Task<bool> DeleteBulk(Expression<Func<T, bool>> filter)
        {
            var collection = GetCollection<T>();
            var deleteResult = await collection.DeleteManyAsync<T>(filter);
            return deleteResult.IsAcknowledged;
        }
    }
}
