using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Excercisel.Repository
{
    public class BaseRepository<T> : IRepository<T>
    {
        private IList<T> _data;

        public BaseRepository(IList<T> data)
        {
            _data = data;
        }

        public void Add(T item) => _data.Add(item);

        public IList<T> GetAll() => _data;

        public void Remove(T item) => _data.Remove(item);
    }
}
