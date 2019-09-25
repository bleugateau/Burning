using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public abstract class AbstractEntity
    {
        [BsonId]
        public int Id { get; set; }
    }
}
