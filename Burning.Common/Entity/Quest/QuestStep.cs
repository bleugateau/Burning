using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity.Quest
{
    public class QuestStep : IEntity
    {
        public string TableName => "quests_steps";

        public int Id { get; set; }

        public int QuestStepId { get; set; }

        public uint QuestId { get; set; }

        public uint NameId { get; set; }

        public uint DescriptionId { get; set; }

        public uint ExperienceReward { get; set; }

        public uint KamasReward { get; set; }

        public uint[] ItemsReward { get; set; }

        public uint[] EmotesReward { get; set; }

        public uint[] JobsReward { get; set; }

        public uint[] SpellsReward { get; set; }

        public uint[] ObjectiveIds { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsNew { get; set; }

        public QuestStep() { }
    }
}
