using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://docs.microsoft.com/ru-ru/dotnet/standard/collections/thread-safe/how-to-create-an-object-pool

namespace GameLogic.Test
{
    /// <summary>
    /// class for object pool
    /// </summary>
    public class ObjectPool<T>
    {
        private readonly ConcurrentBag<T> _objects;

        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ??
                throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }

        public T Get() => 
            _objects.TryTake(out T item) ? item : _objectGenerator();

        public void Return(T item) => 
            _objects.Add(item);
    }
}
