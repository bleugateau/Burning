using Burning.Common.Entity;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.DofusProtocol.Data.D2P;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Repository;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Burning.Emu.World.Entity
{
    public class Character : AbstractEntity
    {
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

        public int ActiveTitle { get; set; }

        public int ActiveOrnament { get; set; }

        [BsonIgnore]
        public Guild Guild
        {
            get
            {
                var guildMember = GuildMemberRepository.Instance.GetGuildMemberFromCharacterId(this.Id);
                return guildMember != null ? guildMember.Guild : null;
            }
        }

        [BsonIgnore]
        public EntityLook Look
        {
            get
            {
                return new Look(this.EntityLook).GetEntityLook();
            }
        }

        [BsonIgnore]
        public List<CharacterOrnament> CharacterOrnament
        {
            get
            {
                return CharacterOrnamentRepository.Instance.GetOrnamentsByCharacter(this);
            }
        }

        [BsonIgnore]
        public List<CharacterTitle> CharacterTitle
        {
            get
            {
                return CharacterTitleRepository.Instance.GetTitlesByCharacter(this);
            }
        }

        [BsonIgnore]
        public Inventory Inventory
        {
            get
            {
                return InventoryRepository.Instance.GetInventoryFromCharacter(this);
            }
        }


        public Character()
        {

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
