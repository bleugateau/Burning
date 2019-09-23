using Burning.Common.Repository;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Common.Entity
{
    public class Guild : IEntity
    {
        public int Id { get; set; }

        public int ownerCharacterId { get; set; }

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

        public List<GuildMember> GuildMembers
        {
            get
            {
                return GuildMemberRepository.Instance.List.FindAll(x => x.Guild == this && x.IsDeleted == false);
            }
        }

        public bool IsDeleted { get; set; }

        public bool IsNew { get; set; }

        public Guild () { }

        public GuildInformations GetGuildInformations()
        {
            return new GuildInformations((uint)this.Id, this.Name, 1, new GuildEmblem((uint)this.SymbolShape, this.SymbolColor, (uint)this.BackgroundShape, this.BackgroundColor));
        }
    }
}
