using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public interface IRepository<T>
    {
        IMongoCollection<T> Collection { get; set; }

        void Initialize(string dataName);

        void Update(T entity);

        void Insert(T entity);
    }
}
