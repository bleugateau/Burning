using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsNew { get; set; }

        bool IsDeleted { get; set; }
    }
}
