using Burning.Common.Entity;
using Burning.Common.Managers.Frame;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Network.Types;
using System.Linq;
using Burning.Emu.World.Game.World;
using Burning.Common.Managers.Database;
using Burning.Emu.World.Repository;
using Burning.Emu.World.Entity;

namespace Burning.Emu.World.Frames
{
    class CharacterFrames : Frame
    {
        //CharactersListRequestMessage
        [PacketId(CharactersListRequestMessage.Id)]
        public void CharactersListRequestMessageFrame(WorldClient client, CharactersListRequestMessage charactersListRequestMessage)
        {
            this.SendCharacterListMessage(client);
            client.SendPacket(new AccountCapabilitiesMessage((uint)client.Account.Id, true, 262143, 262143, 0, true, 1570105606000));
        }

        //StartupActionsExecuteMessage
        [PacketId(StartupActionsExecuteMessage.Id)]
        public void StartupActionsExecuteMessageFrame(WorldClient client, StartupActionsExecuteMessage startupActionsExecuteMessage)
        {
            client.SendPacket(new StartupActionsListMessage(new List<Burning.DofusProtocol.Network.Types.StartupActionAddObject>()));
        }

        [PacketId(CharacterDeletionRequestMessage.Id)]
        public void CharacterDeletionRequestMessageFrame(WorldClient client, CharacterDeletionRequestMessage characterDeletionRequestMessage)
        {
            var character = CharacterRepository.Instance.GetCharacterById((int)characterDeletionRequestMessage.characterId);
            //character.IsDeleted = true;

            if(character.Guild != null)
            {
                //character.Guild.IsDeleted = true;
                var guild = GuildRepository.Instance.GetGuildById(character.Guild.Id);

                foreach (var member in character.Guild.GuildMembers)
                {
                    DatabaseManager.Instance.Delete<Burning.Emu.World.Entity.GuildMember>(GuildMemberRepository.Instance.Collection, member);
                }
                DatabaseManager.Instance.Delete<Guild>(GuildRepository.Instance.Collection, guild);
            }

            DatabaseManager.Instance.Delete<Inventory>(InventoryRepository.Instance.Collection, character.Inventory);
            DatabaseManager.Instance.Delete<Character>(CharacterRepository.Instance.Collection, character);

            this.SendCharacterListMessage(client);
        }

        [PacketId(CharacterCanBeCreatedRequestMessage.Id)]
        public void CharacterCanBeCreatedRequestMessageFrame(WorldClient client, CharacterCanBeCreatedRequestMessage characterCanBeCreatedRequestMessage)
        {
            if(CharacterRepository.Instance.GetCharactersByAccountId(client.Account.Id).Count > 3)
            {
                client.SendPacket(new CharacterCanBeCreatedResultMessage(false));
                return;
            }
            client.SendPacket(new CharacterCanBeCreatedResultMessage(true));
        }


        [PacketId(CharacterCreationRequestMessage.Id)]
        public void CharacterCreationRequestMessageFrame(WorldClient client, CharacterCreationRequestMessage characterCreationRequestMessage)
        {
            Burning.DofusProtocol.Datacenter.Breed breed = BreedRepository.Instance.List.Find(x => x.Id == characterCreationRequestMessage.breed);
            var look = Look.Parse(characterCreationRequestMessage.sex ? breed.FemaleLook : breed.MaleLook);

            for(int i = 1; i < characterCreationRequestMessage.colors.Length; i++)
            {
                look.UpdateColor(i, characterCreationRequestMessage.colors[i]);
            }

            Burning.DofusProtocol.Datacenter.Head head = HeadRepository.Instance.List.Find(x => x.Id == characterCreationRequestMessage.cosmeticId);
            short skin = short.Parse(head.Skins);
            look.AddSkin((uint)skin);

            Character character = new Character()
            {
                Id = DatabaseManager.Instance.AutoIncrement<Character>(CharacterRepository.Instance.Collection),
                AccountId = client.Account.Id,
                Name = characterCreationRequestMessage.name,
                Breed = (sbyte)characterCreationRequestMessage.breed,
                Experience = 0,
                Level = 1,
                CellId = 218,
                MapId = 88081688,
                Kamas = 1000,
                Sex = characterCreationRequestMessage.sex,
                EntityLook = look.GetDatas()
            };

            CharacterRepository.Instance.Insert(character); //creation of character


            var item = ItemRepository.Instance.GetItemDataById(1467);
            //item.possibleEffects

            Inventory inventory = new Inventory()
            {
                Id = DatabaseManager.Instance.AutoIncrement<Inventory>(InventoryRepository.Instance.Collection),
                CharacterId = character.Id,
                ObjectItems = new List<ObjectItem>() { InventoryRepository.Instance.GenerateItemFromId(14076)  }
            };

            InventoryRepository.Instance.Insert(inventory); //creation of inventory

            client.SendPacket(new CharacterCreationResultMessage((uint)CharacterCreationResultEnum.OK));
            this.SendCharacterListMessage(client, true);
        }

        [PacketId(TitlesAndOrnamentsListRequestMessage.Id)]
        public void TitlesAndOrnamentsListRequestMessageFrame(WorldClient client, TitlesAndOrnamentsListRequestMessage titlesAndOrnamentsListRequestMessage)
        {

            List<uint> ornaments = new List<uint>();
            foreach (var ornament in client.ActiveCharacter.CharacterOrnament)
                ornaments.Add((uint)ornament.OrnamentId);

            List<uint> titles = new List<uint>();
            foreach (var title in client.ActiveCharacter.CharacterTitle)
                titles.Add((uint)title.TitleId);

            client.SendPacket(new TitlesAndOrnamentsListMessage(titles, ornaments, (uint)client.ActiveCharacter.ActiveTitle, (uint)client.ActiveCharacter.ActiveOrnament));
        }

        [PacketId(TitleSelectRequestMessage.Id)]
        public void TitleSelectRequestMessageFrame(WorldClient client, TitleSelectRequestMessage titleSelectRequestMessage)
        {

            if(client.ActiveCharacter.CharacterTitle.Find(x => x.TitleId == titleSelectRequestMessage.titleId) == null)
            {
                client.SendPacket(new TitleSelectErrorMessage(0));
                return;
            }

            client.ActiveCharacter.ActiveTitle = (int)titleSelectRequestMessage.titleId;
            client.SendPacket(new TitleSelectedMessage(titleSelectRequestMessage.titleId));
        }

        [PacketId(OrnamentSelectRequestMessage.Id)]
        public void OrnamentSelectRequestMessageFrame(WorldClient client, OrnamentSelectRequestMessage ornamentSelectRequestMessage)
        {
            if (client.ActiveCharacter.CharacterOrnament.Find(x => x.OrnamentId == ornamentSelectRequestMessage.ornamentId) == null)
            {
                client.SendPacket(new OrnamentSelectErrorMessage(0));
                return;
            }

            client.ActiveCharacter.ActiveOrnament = (int)ornamentSelectRequestMessage.ornamentId;
            client.SendPacket(new OrnamentSelectedMessage(ornamentSelectRequestMessage.ornamentId));
        }

        [PacketId(CharacterFirstSelectionMessage.Id)]
        public void CharacterFirstSelectionMessageFrame(WorldClient client, CharacterFirstSelectionMessage characterFirstSelectionMessage)
        {
            var character = CharacterRepository.Instance.GetCharacterById((int)characterFirstSelectionMessage.id);

            if (character == null)
            {
                client.SendPacket(new CharacterSelectedErrorMessage());
                return;
            }

            client.ActiveCharacter = character;
            this.SendCharacterSelectionSuccess(client);
        }

        [PacketId(CharacterSelectionMessage.Id)]
        public void CharacterSelectionMessageFrame(WorldClient client, CharacterSelectionMessage characterSelectionMessage)
        {
            var character = CharacterRepository.Instance.GetCharacterById((int)characterSelectionMessage.id);

            if(character == null)
            {
                client.SendPacket(new CharacterSelectedErrorMessage());
                return;
            }

            client.ActiveCharacter = character;

            this.SendCharacterListMessage(client);
            this.SendCharacterSelectionSuccess(client);
        }

        /**
         * Send character selection success
         */
        public void SendCharacterSelectionSuccess(WorldClient client)
        {
            client.SendPacket(new NotificationListMessage(new List<int>() { }));
            client.SendPacket(new CharacterSelectedSuccessMessage(new Burning.DofusProtocol.Network.Types.CharacterBaseInformations(client.ActiveCharacter.Id, client.ActiveCharacter.Name, (uint)client.ActiveCharacter.Level, client.ActiveCharacter.Look, client.ActiveCharacter.Breed, client.ActiveCharacter.Sex), false));
            client.SendPacket(new SpellListMessage(true, new List<Burning.DofusProtocol.Network.Types.SpellItem>()));
            client.SendPacket(new ShortcutBarContentMessage((uint)ShortcutBarEnum.GENERAL_SHORTCUT_BAR, new List<Burning.DofusProtocol.Network.Types.Shortcut>()));
            client.SendPacket(new InventoryContentMessage(client.ActiveCharacter.Inventory.ObjectItems, 0));
            client.SendPacket(new PresetsMessage(new List<Preset>()));
            client.SendPacket(new RoomAvailableUpdateMessage(1));
            client.SendPacket(new HavenBagPackListMessage(new List<int>() { 1, 2, 3, 4, 5, 6 }));
            client.SendPacket(new EmoteListMessage(new List<uint>() { 1, 19, 22, 97 }));

            client.SendPacket(new JobDescriptionMessage(new List<JobDescription>() {

                new JobDescription(36, new List<SkillActionDescription>()
                {
                    new SkillActionDescriptionCollect(124, 30, 1, 7),
                    new SkillActionDescriptionCollect(301, 30, 1, 1),
                    new SkillActionDescriptionCraft(135, 100)
                })

            }));
            client.SendPacket(new JobExperienceMultiUpdateMessage(new List<JobExperience>()
            {
                new JobExperience(36, 56, 100, 0, 150)
            }));
            client.SendPacket(new JobCrafterDirectorySettingsMessage(new List<JobCrafterDirectorySettings>()
            {
                new JobCrafterDirectorySettings(36, 0, true)
            }));

            var guild = client.ActiveCharacter.Guild;
            if (guild != null)
            {
                var memberInfos = guild.GuildMembers.Find(x => x.CharacterId == client.ActiveCharacter.Id);
                client.SendPacket(new GuildMembershipMessage(new GuildInformations((uint)guild.Id, guild.Name, (uint)guild.Level, new GuildEmblem((uint)guild.SymbolShape, guild.SymbolColor, (uint)guild.BackgroundShape, guild.BackgroundColor)), (memberInfos != null ? (uint)memberInfos.PossessedRight : 0)));
                client.SendPacket(new GuildInformationsGeneralMessage(false, (uint)guild.Level, 0, guild.Experience, 1000, (uint)guild.CreationDate, 1, (uint)client.ActiveCharacter.Guild.GuildMembers.Count));

                foreach (var member in guild.GuildMembers.FindAll(x => x.Character.Id != client.ActiveCharacter.Id))
                {
                    var memberClient = WorldManager.Instance.GetClientFromCharacter(member.Character);

                    if (memberClient != null)
                        memberClient.SendPacket(new TextInformationMessage(0, 224, new List<string>() { client.ActiveCharacter.Name, client.ActiveCharacter.Id.ToString() }));
                }
            }

            //DARE ???
            client.SendPacket(new DareCreatedListMessage(new List<Burning.DofusProtocol.Network.Types.DareInformations>(), new List<Burning.DofusProtocol.Network.Types.DareVersatileInformations>()));
            client.SendPacket(new DareSubscribedListMessage(new List<Burning.DofusProtocol.Network.Types.DareInformations>(), new List<Burning.DofusProtocol.Network.Types.DareVersatileInformations>()));
            client.SendPacket(new DareWonListMessage(new List<double>()));
            client.SendPacket(new DareRewardsListMessage(new List<Burning.DofusProtocol.Network.Types.DareReward>()));

            client.SendPacket(new AlignmentRankUpdateMessage(1, true));
            client.SendPacket(new InventoryWeightMessage(0, 0, 1000));
            client.SendPacket(new FollowedQuestsMessage(new List<Burning.DofusProtocol.Network.Types.QuestActiveDetailedInformations>()));

            //statistique du personnage
            ActorExtendedAlignmentInformations actorExtendedAlignment = new ActorExtendedAlignmentInformations(0, 0, 0, 0, 0, 0, 0, 0);
            #region stats

            CharacterBaseCharacteristic fireElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic airElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic waterElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic earthElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic neutralElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic fireElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic airElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic waterElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pushDamageReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic earthElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic dodgePMLostProbability = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic dodgePALostProbability = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic fireDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic airDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic waterDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic earthDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic neutralDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic criticalDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic neutralElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic PMAttack = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic criticalDamageReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpEarthElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic spellDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic spellDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic weaponDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic weaponDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic rangedDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic rangedDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpNeutralElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic meleeDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpFireElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpAirElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpWaterElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpEarthElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpNeutralElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpFireElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpAirElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pvpWaterElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic meleeDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic PAAttack = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic pushDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic tackleBlock = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic actionPoints = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic prospecting = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic initiative = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic tackleEvade = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic strength = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic movementPoints = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic wisdom = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic permanentDamagePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic runeBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic glyphBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic trapBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic trapBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic damagesBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic vitality = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic allDamagesBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic healBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic weaponDamagesBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic criticalHit = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic reflect = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic summonableCreaturesBoost = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic range = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic intelligence = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic agility = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic chance = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);
            CharacterBaseCharacteristic criticalMiss = new CharacterBaseCharacteristic(0, 0, 0, 0, 0);

            #endregion

            CharacterCharacteristicsInformations characterCharacteristics = new CharacterCharacteristicsInformations(client.ActiveCharacter.Experience, 0, 1000, 0, client.ActiveCharacter.Kamas, 0, 0, 0, actorExtendedAlignment,
                45, 45, 5000, 10000, 6, 3, initiative, prospecting, actionPoints, movementPoints, strength, vitality, wisdom, chance, agility, intelligence, range, summonableCreaturesBoost, reflect, criticalHit, 0,
                criticalMiss, healBonus, allDamagesBonus, weaponDamagesBonusPercent, damagesBonusPercent, trapBonus, trapBonusPercent, glyphBonusPercent, runeBonusPercent, permanentDamagePercent,
                tackleBlock, tackleEvade, PAAttack, PMAttack, pushDamageBonus, criticalDamageBonus, neutralDamageBonus, earthDamageBonus, waterDamageBonus, airDamageBonus, fireDamageBonus, dodgePALostProbability,
                dodgePMLostProbability, neutralElementResistPercent, earthElementResistPercent, waterElementResistPercent, airElementResistPercent, fireElementResistPercent, neutralElementReduction, earthElementReduction,
                waterElementReduction, airElementReduction, fireElementReduction, pushDamageReduction, criticalDamageReduction, pvpNeutralElementResistPercent, pvpEarthElementResistPercent, pvpWaterElementResistPercent,
                pvpAirElementResistPercent, pvpFireElementResistPercent, pvpNeutralElementReduction, pvpEarthElementReduction, pvpWaterElementReduction, pvpAirElementReduction, pvpFireElementReduction,
                meleeDamageDonePercent, meleeDamageReceivedPercent, rangedDamageDonePercent, rangedDamageReceivedPercent, weaponDamageDonePercent, weaponDamageReceivedPercent, spellDamageDonePercent,
                spellDamageReceivedPercent, new List<CharacterSpellModification>(), 0);
            client.SendPacket(new CharacterStatsListMessage(characterCharacteristics));


            client.SendPacket(new SpouseStatusMessage(false));
            client.SendPacket(new AchievementListMessage(new List<AchievementAchieved>())); //success ?
            client.SendPacket(new CharacterCapabilitiesMessage(4095)); //guild emblem id ??
            client.SendPacket(new AlmanachCalendarDateMessage(1));
            client.SendPacket(new IdolListMessage(new List<uint>(), new List<uint>(), new List<PartyIdol>())); //idol
            client.SendPacket(new CharacterExperienceGainMessage(0, 0, 0, 0)); //???
            client.SendPacket(new AccountHouseMessage(new List<AccountHouseInformations>())); //house
            client.SendPacket(new CharacterLoadingCompleteMessage()); //end of load


            client.SendPacket(new TextInformationMessage(1, 89, new List<string>()));

            if (guild != null && guild.Bulletin != null)
            {
                client.SendPacket(new GuildMotdMessage(guild.Announce, 0, 1, client.ActiveCharacter.Name));
                client.SendPacket(new GuildBulletinMessage(guild.Bulletin, 0, 1, client.ActiveCharacter.Name, 0));
            }
        }

        /*
         * Send character list for multiple way
         */
        public void SendCharacterListMessage(WorldClient client, bool isCreationResult = false)
        {
            List<Character> characters = CharacterRepository.Instance.GetCharactersByAccountId(client.Account.Id);

            List<Burning.DofusProtocol.Network.Types.CharacterBaseInformations> characterBaseInformations = new List<Burning.DofusProtocol.Network.Types.CharacterBaseInformations>();
            foreach (var character in characters)
            {
                characterBaseInformations.Add(new Burning.DofusProtocol.Network.Types.CharacterBaseInformations(character.Id, character.Name, (uint)character.Level, character.Look, character.Breed, character.Sex));
            }

            if (isCreationResult)
                characterBaseInformations.Reverse();

            client.SendPacket(new CharactersListMessage(characterBaseInformations, false));
        }
    }
}
