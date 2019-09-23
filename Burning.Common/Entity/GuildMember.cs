using Burning.Common.Managers.Guild;
using Burning.Common.Repository;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class GuildMember : IEntity
    {
        public int Id { get; set; }

        public int GuildId { get; set; }

        public int CharacterId { get; set; }

        public int Role { get; set; }

        public int PossessedRight { get; set; }

        public int PourcentageXpGiven { get; set; }

        public Guild Guild
        {
            get
            {
                return GuildRepository.Instance.List.Find(x => x.Id == this.GuildId);
            }
        }

        public Character Character
        {
            get
            {
                return CharacterRepository.Instance.List.Find(x => x.Id == this.CharacterId);
            }
        }

        public Dictionary<GuildRightsBitEnum, bool> GuildRightsItemCriterion
        {
            get
            {
                return GuildRightsManager.GetRights((uint)this.PossessedRight);
            }
        }

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public GuildMember() { }

        public GuildMember(int guildId, int characterId)
        {
            this.GuildId = guildId;
            this.CharacterId = characterId;
        }
    }
}
