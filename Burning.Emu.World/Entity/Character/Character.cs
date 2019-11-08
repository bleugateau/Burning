using Burning.Common.Entity;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.DofusProtocol.Data.D2P;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Game.Fight;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Game.Level;
using Burning.Emu.World.Repository;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public double Experience { get; set; }

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

        [BsonIgnore]
        public CharacterCharacteristic Characteristics
        {
            get
            {
                return CharacterCharacteristicRepository.Instance.GetCharacteristicsByCharacter(this);
            }
        }

        [BsonIgnore]
        public Fight Fight
        {
            get
            {
                return FightManager.Instance.Fights.Where(x => x.FightState != FightStateEnum.FIGHT_ENDED && ((x.Defenders.Find(d => d is CharacterFighter && d.Id == this.Id) != null) || (x.Challengers.Find(c => c is CharacterFighter && c.Id == this.Id) != null))).Select(f => f).FirstOrDefault();
            }
        }

        [BsonIgnore]
        public Breed BreedData
        {
            get
            {
                return BreedRepository.Instance.GetBreedById(this.Breed);
            }
        }

        [BsonIgnore]
        public List<CharacterShortcut> CharacterShortcutBars
        {
            get
            {
                return CharacterShortcutRepository.Instance.GetShortcutByCharacterId(this.Id);
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

        public CharacterCharacteristicsInformations GetCharacterCharacteristicsInformations()
        {
            var characteristics = this.Characteristics;

            ActorExtendedAlignmentInformations actorExtendedAlignment = new ActorExtendedAlignmentInformations(0, 0, 0, 0, 0, 0, 0, 0);

            characteristics.initiative.@base += (characteristics.agility.@base + characteristics.chance.@base + characteristics.intelligence.@base + characteristics.strength.@base + characteristics.vitality.@base + characteristics.wisdom.@base);
            characteristics.initiative.objectsAndMountBonus += (characteristics.chance.objectsAndMountBonus + characteristics.intelligence.objectsAndMountBonus + characteristics.strength.objectsAndMountBonus + characteristics.vitality.objectsAndMountBonus + characteristics.wisdom.objectsAndMountBonus);



            return new CharacterCharacteristicsInformations(this.Experience, LevelManager.Instance.GetActualLevelExperience<Character>(this).Experience, LevelManager.Instance.GetNextLevelByExperience<Character>(this).Experience, 0, this.Kamas, (uint)characteristics.CapitalPoint, 0, 0, actorExtendedAlignment,
                (uint)characteristics.LifeBase + (uint)characteristics.vitality.Total, (uint)characteristics.LifeBase + (uint)characteristics.vitality.Total, 5000, 10000, characteristics.PA, characteristics.PM, characteristics.initiative, characteristics.prospecting, characteristics.actionPoints, characteristics.movementPoints, characteristics.strength, characteristics.vitality, characteristics.wisdom, characteristics.chance, characteristics.agility, characteristics.intelligence, characteristics.range, characteristics.summonableCreaturesBoost, characteristics.reflect, characteristics.criticalHit, 0,
                characteristics.criticalMiss, characteristics.healBonus, characteristics.allDamagesBonus, characteristics.weaponDamagesBonusPercent, characteristics.damagesBonusPercent, characteristics.trapBonus, characteristics.trapBonusPercent, characteristics.glyphBonusPercent, characteristics.runeBonusPercent, characteristics.permanentDamagePercent,
                characteristics.tackleBlock, characteristics.tackleEvade, characteristics.PAAttack, characteristics.PMAttack, characteristics.pushDamageBonus, characteristics.criticalDamageBonus, characteristics.neutralDamageBonus, characteristics.earthDamageBonus, characteristics.waterDamageBonus, characteristics.airDamageBonus, characteristics.fireDamageBonus, characteristics.dodgePALostProbability,
                characteristics.dodgePMLostProbability, characteristics.neutralElementResistPercent, characteristics.earthElementResistPercent, characteristics.waterElementResistPercent, characteristics.airElementResistPercent, characteristics.fireElementResistPercent, characteristics.neutralElementReduction, characteristics.earthElementReduction,
                characteristics.waterElementReduction, characteristics.airElementReduction, characteristics.fireElementReduction, characteristics.pushDamageReduction, characteristics.criticalDamageReduction, characteristics.pvpNeutralElementResistPercent, characteristics.pvpEarthElementResistPercent, characteristics.pvpWaterElementResistPercent,
                characteristics.pvpAirElementResistPercent, characteristics.pvpFireElementResistPercent, characteristics.pvpNeutralElementReduction, characteristics.pvpEarthElementReduction, characteristics.pvpWaterElementReduction, characteristics.pvpAirElementReduction, characteristics.pvpFireElementReduction,
                characteristics.meleeDamageDonePercent, characteristics.meleeDamageReceivedPercent, characteristics.rangedDamageDonePercent, characteristics.rangedDamageReceivedPercent, characteristics.weaponDamageDonePercent, characteristics.weaponDamageReceivedPercent, characteristics.spellDamageDonePercent,
                characteristics.spellDamageReceivedPercent, new List<CharacterSpellModification>(), 0);
        }

        public void OnLevelUp()
        {
            this.Level += 1;

            var characteristic = this.Characteristics;

            characteristic.CapitalPoint += 5;
            characteristic.LifeBase += 5;

            CharacterRepository.Instance.Update(this);
            CharacterCharacteristicRepository.Instance.Update(characteristic);
        }

        public List<Spell> GetSpells()
        {
            List<Spell> spells = new List<Spell>();
            var breed = this.BreedData;

            if(breed != null)
            {
                foreach(var spellId in breed.BreedSpellsId)
                {
                    var spell = SpellRepository.Instance.GetSpellById((int)spellId);
                    if (spell != null)
                        spells.Add(spell);
                }
            }

            return spells;
        }

        public List<SpellItem> GetAvaibleSpells()
        {
            List<SpellItem> avaibleSpells = new List<SpellItem>();
            var spells = this.GetSpells();

            if (spells != null)
            {
                foreach (var spell in spells)
                {
                    int level = 0;
                    foreach(var spellLevel in spell.SpellLevels)
                    {
                        var spellLevelData = SpellLevelRepository.Instance.GetSpellLevelById((int)spellLevel);

                        if (spellLevelData != null && spellLevelData.MinPlayerLevel <= this.Level)
                            level += 1;
                    }

                    if(level != 0)
                        avaibleSpells.Add(new SpellItem(spell.Id, level));
                }
            }
            
            return avaibleSpells;
        }
    }
}
