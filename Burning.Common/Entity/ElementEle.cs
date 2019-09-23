using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class ElementEle : IEntity
    {
        public int Id { get; set; }

        public int GfxId { get; set; }

        public int ElementId { get; set; }

        public int TypeId { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public ElementEle() { }
    }
}
