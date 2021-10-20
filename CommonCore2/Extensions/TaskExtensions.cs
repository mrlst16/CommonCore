using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonCore2.Threading
{
    public static class TaskExtensions
    {
        public async static Task<IEnumerable<TReturnType>> ProcessInChunks<TRequestType, TReturnType>(
            this Func<TRequestType, Task<TReturnType>> func,
            IEnumerable<TRequestType> data,
            int chunksize = 10)
        {
            if (chunksize <= 0) throw new Exception("Chunk size must be greater than 0");

            var result = new List<TReturnType>();
            var queue = new Queue<Task<IEnumerable<TReturnType>>>();

            var skip = 0;
            while (skip <= data.Count())
            {
                var dataLocal = data.Skip(skip).Take(chunksize);

                var tasks = func.ProcessInChunks(dataLocal);
                queue.Enqueue(tasks);
                skip += chunksize;
            }

            while (queue.TryDequeue(out Task<IEnumerable<TReturnType>> tasks))
            {
                var res = await tasks;
                result.AddRange(res);
            }

            return result;
        }

        private async static Task<IEnumerable<TReturnType>> ProcessInChunks<TRequestType, TReturnType>(
           this Func<TRequestType, Task<TReturnType>> func,
           IEnumerable<TRequestType> data
            )
        {
            var result = new List<TReturnType>();
            var queue = new Queue<Task<TReturnType>>();

            foreach (var datum in data)
            {
                var task = func(datum);
                queue.Enqueue(task);
            }
            while (queue.TryDequeue(out Task<TReturnType> task))
            {
                var res = await task;
                result.Add(res);
            }
            return result;
        }
    }
}
