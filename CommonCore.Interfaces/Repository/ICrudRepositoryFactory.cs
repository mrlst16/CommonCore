using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Interfaces.Repository
{
    public interface ICrudRepositoryFactory
    {
        ICrudRepository<T> Get<T>();
    }
}
