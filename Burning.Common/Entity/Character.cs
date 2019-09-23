using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.DofusProtocol.Data.D2P;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burning.Common.Entity
{
    public class Character : IEntity
    {

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }

        public byte[] EntityLook { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public bool Sex { get; set; }

        public sbyte Breed { get; set; }

        public int Kamas { get; set; }

        public int MapId { get; set; }

        public int CellId { get; set; }

        public Map MapData
        {
            get
            {
                return MapRepository.Instance.GetMap(this.MapId);
            }
        }

        public int ActiveTitle { get; set; }
        public int ActiveOrnament { get; set; }

        public Guild Guild {
            get
            {
                var guildMember = GuildMemberRepository.Instance.List.Find(x => x.IsDeleted == false && x.Character == this);
                return guildMember != null ? guildMember.Guild : null;
            }
        }
             
        public bool IsDeleted { get; set; }

        public bool IsNew { get;set; }

        public EntityLook Look
        {
            get
            {
                return new Look(this.EntityLook).GetEntityLook();
            }
        }

        public List<CharacterOrnament> CharacterOrnament
        {
            get
            {
                return CharacterOrnamentRepository.Instance.List.FindAll(x => x.CharacterId == this.Id);
            }
        }

        public List<CharacterTitle> CharacterTitle
        {
            get
            {
                return CharacterTitleRepository.Instance.List.FindAll(x => x.CharacterId == this.Id);
            }
        }

        private Look look { get; set; }


        public Character() : base()
        {
            this.IsDeleted = false;
            this.IsNew = false;
        }

        public GameRolePlayCharacterInformations GetGameRolePlayCharacterInformations()
        {
            List<HumanOption> humanOptions = new List<HumanOption>();

            if (this.ActiveTitle != 0)
                humanOptions.Add(new HumanOptionTitle((uint)this.ActiveTitle, ""));

            if (this.ActiveOrnament != 0)
                humanOptions.Add(new HumanOptionOrnament((uint)this.ActiveOrnament, (uint)this.Level, 0, 0));

            if (this.Guild != null)
                humanOptions.Add(new HumanOptionGuild(new GuildInformations((uint)this.Guild.Id, this.Guild.Name, 1, new GuildEmblem((uint)this.Guild.SymbolShape, this.Guild.SymbolColor, (uint)this.Guild.BackgroundShape, this.Guild.BackgroundColor))));

            HumanInformations humanInformations = new HumanInformations(new ActorRestrictionsInformations(), this.Sex, humanOptions.ToArray());
            return new GameRolePlayCharacterInformations(this.Id, new EntityDispositionInformations(this.CellId, 2), this.Look, this.Name, humanInformations, (uint)this.AccountId, new ActorAlignmentInformations(0, 0, 0, 0));
        }

    }
}
