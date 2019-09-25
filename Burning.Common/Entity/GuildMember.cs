using Burning.Common.Managers.Guild;
using Burning.Common.Repository;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class GuildMember : AbstractEntity
    {

        public int GuildId { get; set; }

        public int CharacterId { get; set; }

        public int Role { get; set; }

        public int PossessedRight { get; set; }

        public int PourcentageXpGiven { get; set; }

        [BsonIgnore]
        public Guild Guild
        {
            get
            {
                return GuildRepository.Instance.GetGuildById(this.GuildId);
            }
        }

        [BsonIgnore]
        public Character Character
        {
            get
            {
                return CharacterRepository.Instance.GetCharacterById(this.CharacterId);
            }
        }

        [BsonIgnore]
        public Dictionary<GuildRightsBitEnum, bool> GuildRightsItemCriterion
        {
            get
            {
                return GuildRightsManager.GetRights((uint)this.PossessedRight);
            }
        }

        public GuildMember() { }

        public GuildMember(int guildId, int characterId)
        {
            this.GuildId = guildId;
            this.CharacterId = characterId;
        }
    }
}
