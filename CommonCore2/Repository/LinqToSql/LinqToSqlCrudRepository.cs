using CommonCore.Interfaces.Repository;
using CommonCore.Models.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CommonCore2.Repository.LinqToSql
{
    public class LinqToSqlCrudRepository<T> : ICrudRepository<T>
    {
        private readonly string _connectionString;

        public LinqToSqlCrudRepository(
            string connectionString
            )
        {
            _connectionString = connectionString;
        }

        protected bool TryCallingDatabase(string query, out DataSet result)
        {
            try
            {
                result = new DataSet();
                using (SqlConnection connection = new(_connectionString))
                using (SqlCommand command = new SqlCommand(query))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                    return true;
                }
            }
            catch (Exception e)
            {
                result = null;
                return false;
            }
        }

        public async Task Create(IEnumerable<T> items)
        {

        }

        public async Task Create(T items)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBulk(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<T> First(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Read(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Read(SearchRequest<T> searchRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool, T)> Update(T item, Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
