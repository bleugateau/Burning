using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Burning.Common.Entity.Quest
{
    class QuestObjective : IEntity
    {
        public string TableName => "quests_objectives";

        public int Id { get; set; }

        public uint QuestObjectiveId { get; set; }

        public uint StepId { get; set; }

        public uint TypeId { get; set; }

        public uint[] Parameters { get; set; }

        public Point coords;

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public QuestObjective() { }
    }
}
