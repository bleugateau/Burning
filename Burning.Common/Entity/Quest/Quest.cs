using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity.Quest
{
    class Quest : IEntity
    {
        public string TableName => "quests";

        public int Id { get; set; }

        public uint QuestId { get; set; }

        public uint NameId { get; set; }

        public uint[] StepIds { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public Quest() { }
    }
}
