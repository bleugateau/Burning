using Burning.Common.Entity;
using Burning.Common.Repository;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Repository;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Entity
{
    public class Guild : AbstractEntity
    {
        public int OwnerCharacterId { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public string Announce { get; set; }

        public string Bulletin { get; set; }

        public int SymbolShape { get; set; }

        public int SymbolColor { get; set; }

        public int BackgroundShape { get; set; }

        public int BackgroundColor { get; set; }

        public int CreationDate { get; set; }
        
        [BsonIgnore]
        public List<GuildMember> GuildMembers
        {
            get
            {
                return GuildMemberRepository.Instance.GetGuildMembersFromGuildId(this.Id);
            }
        }

        public Guild () { }

        public GuildInformations GetGuildInformations()
        {
            return new GuildInformations((uint)this.Id, this.Name, 1, new GuildEmblem((uint)this.SymbolShape, this.SymbolColor, (uint)this.BackgroundShape, this.BackgroundColor));
        }
    }
}
