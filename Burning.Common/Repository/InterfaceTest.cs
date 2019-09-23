using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Repository
{
    public interface InterfaceTest<T>
    {
        RepositoryAccessor Accessor { get; set; }
        List<T> List { get; set; }
        string TableName { get; set; }
        void Initialize(string tableName);
    }
}
