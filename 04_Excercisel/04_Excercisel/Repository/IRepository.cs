using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Excercisel.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Remove(T item);

        IList<T> GetAll();
    }
}
