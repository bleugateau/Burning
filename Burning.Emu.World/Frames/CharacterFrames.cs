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


            DatabaseManager.Instance.Delete<CharacterCharacteristic>(CharacterCharacteristicRepository.Instance.Collection, character.Characteristics);
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

            CharacterCharacteristic characterCharacteristic = new CharacterCharacteristic()
            {
                Id = DatabaseManager.Instance.AutoIncrement<CharacterCharacteristic>(CharacterCharacteristicRepository.Instance.Collection),
                CharacterId = character.Id,
                CapitalPoint = 100,
                LifeBase = 45,
                fireElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                airElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                waterElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                earthElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                neutralElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                fireElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                airElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                waterElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pushDamageReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                earthElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                dodgePMLostProbability = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                dodgePALostProbability = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                fireDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                airDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                waterDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                earthDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                neutralDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                criticalDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                neutralElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                PMAttack = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                criticalDamageReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpEarthElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                spellDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                spellDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                weaponDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                weaponDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                rangedDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                rangedDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpNeutralElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                meleeDamageReceivedPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpFireElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpAirElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpWaterElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpEarthElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpNeutralElementReduction = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpFireElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpAirElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pvpWaterElementResistPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                meleeDamageDonePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                PAAttack = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                pushDamageBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                tackleBlock = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                actionPoints = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                prospecting = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                initiative = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                tackleEvade = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                strength = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                movementPoints = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                wisdom = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                permanentDamagePercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                runeBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                glyphBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                trapBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                trapBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                damagesBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                vitality = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                allDamagesBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                healBonus = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                weaponDamagesBonusPercent = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                criticalHit = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                reflect = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                summonableCreaturesBoost = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                range = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                intelligence = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                agility = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                chance = new CharacterBaseCharacteristic(0, 0, 0, 0, 0),
                criticalMiss = new CharacterBaseCharacteristic(0, 0, 0, 0, 0)
            };

            CharacterCharacteristicRepository.Instance.Insert(characterCharacteristic);

            Inventory inventory = new Inventory()
            {
                Id = DatabaseManager.Instance.AutoIncrement<Inventory>(InventoryRepository.Instance.Collection),
                CharacterId = character.Id,
                ObjectItems = new List<ObjectItem>()
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
            client.SendPacket(new InventoryContentMessage(InventoryRepository.Instance.GetStackedItem(client.ActiveCharacter.Inventory), 0));
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

            
            client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));


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
