using CommonCore.Interfaces.Repository;

namespace CommonCore2.Repository.MongoDb
{
    public class MongoDbCrudRepositoryFactory : ICrudRepositoryFactory
    {
        private readonly string _connectionString;

        public MongoDbCrudRepositoryFactory(
            string connectionString
            )
        {
            _connectionString = connectionString;
        }

        public ICrudRepository<T> Get<T>()
            => new MongoDbCrudRepository<T>(_connectionString);
    }
}
