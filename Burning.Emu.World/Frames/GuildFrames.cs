using Burning.Common.Managers.Frame;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Burning.Common.Repository;
using Burning.Common.Entity;
using Burning.Emu.World.Game.World;
using Burning.Emu.World.Game.Guild;
using Burning.DofusProtocol.Datacenter;
using Burning.Common.Managers.Database;
using Burning.Emu.World.Repository;
using Burning.Emu.World.Entity;

namespace Burning.Emu.World.Frames
{
    class GuildFrames : Frame
    {
        [PacketId(GuildCreationValidMessage.Id)]
        public void ChatClientMultiMessageFrame(WorldClient client, GuildCreationValidMessage guildCreationValidMessage)
        {

            if (!Regex.IsMatch(guildCreationValidMessage.guildName, @"^\b[A-Z][A-Za-z\s-']{4,30}\b$", RegexOptions.Compiled) || Regex.IsMatch(guildCreationValidMessage.guildName, @"^\s\s$"))
            {
                client.SendPacket(new GuildCreationResultMessage((uint)SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_ERROR_NAME_INVALID));
                return;
            }

            if(client.ActiveCharacter.Guild != null)
            {
                client.SendPacket(new GuildCreationResultMessage((uint)SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_ERROR_ALREADY_IN_GROUP));
                return;
            }

            if(GuildRepository.Instance.IsNameAlreadyExist(guildCreationValidMessage.guildName))
            {
                client.SendPacket(new GuildCreationResultMessage((uint)SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_ERROR_NAME_ALREADY_EXISTS));
                return;
            }

            var guild = new Guild()
            {
                Id = DatabaseManager.Instance.AutoIncrement<Guild>(GuildRepository.Instance.Collection),
                Name = guildCreationValidMessage.guildName,
                OwnerCharacterId = client.ActiveCharacter.Id,
                Level = 1,
                Experience = 0,
                SymbolColor = guildCreationValidMessage.guildEmblem.symbolColor,
                SymbolShape = (int)guildCreationValidMessage.guildEmblem.symbolShape,
                BackgroundColor = guildCreationValidMessage.guildEmblem.backgroundColor,
                BackgroundShape = (int)guildCreationValidMessage.guildEmblem.backgroundShape,
                CreationDate = (int)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds //a patch pas bonne date
            };

            GuildRepository.Instance.Insert(guild);

            var guildMember = new GuildMember(guild.Id, client.ActiveCharacter.Id)
            {
                Id = DatabaseManager.Instance.AutoIncrement<GuildMember>(GuildMemberRepository.Instance.Collection),
                Role = 1,
                PossessedRight = 262145,
                PourcentageXpGiven = 0
            };

            GuildMemberRepository.Instance.Insert(guildMember);

            client.SendPacket(new GuildInformationsPaddocksMessage(5, new List<Burning.DofusProtocol.Network.Types.PaddockContentInformations>()));
            client.SendPacket(new GuildHousesInformationMessage(new List<Burning.DofusProtocol.Network.Types.HouseInformationsForGuild>()));
            client.SendPacket(new GuildCreationResultMessage((uint)SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_OK));
            client.SendPacket(new GuildJoinedMessage(client.ActiveCharacter.Guild.GetGuildInformations(), (uint)guildMember.Role));
        }

        [PacketId(GuildInvitationMessage.Id)]
        public void GuildInvitationMessageFrame(WorldClient client, GuildInvitationMessage guildInvitationMessage)
        {
            if (client.ActiveCharacter.Guild == null)
                return;

            //check si il a le droit d'inviter a faire
            var member = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character.Id == client.ActiveCharacter.Id);

            if (!member.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_INVITE_NEW_MEMBERS])
            {
                client.SendPacket(new GuildInvitationStateRecruterMessage("", (uint)SocialGroupInvitationStateEnum.SOCIAL_GROUP_INVITATION_FAILED));
                return;
            }

            var target = WorldManager.Instance.worldClients.Find(x => x.ActiveCharacter != null && x.ActiveCharacter.Id == guildInvitationMessage.targetId);

            if(target == null || target.ActiveCharacter.Guild != null)
                return;

            //ajouter dans la liste guildinvitation
            GuildManager.Instance.AddGuildInvitations(new GuildInvitation(client.ActiveCharacter.Guild.Id, client.ActiveCharacter.Id, target.ActiveCharacter.Id));

            client.SendPacket(new GuildInvitationStateRecruterMessage(target.ActiveCharacter.Name, (uint)SocialGroupInvitationStateEnum.SOCIAL_GROUP_INVITATION_SENT));
            target.SendPacket(new GuildInvitedMessage(client.ActiveCharacter.Id, client.ActiveCharacter.Name, client.ActiveCharacter.Guild.GetGuildInformations()));
        }


        [PacketId(GuildInvitationAnswerMessage.Id)]
        public void GuildInvitationAnswerMessageFrame(WorldClient client, GuildInvitationAnswerMessage guildInvitationAnswerMessage)
        {
            Console.WriteLine(guildInvitationAnswerMessage.accept);

            var invitation = GuildManager.Instance.GetGuildInvitation(client.ActiveCharacter);

            if (client.ActiveCharacter.Guild != null || invitation == null)
                return;

            var senderClient = WorldManager.Instance.GetClientFromCharacter(CharacterRepository.Instance.GetCharacterById(client.ActiveCharacter.Id));

            if (guildInvitationAnswerMessage.accept)
            {
                var guildMember = new GuildMember(invitation.GuildId, client.ActiveCharacter.Id)
                {
                    Id = DatabaseManager.Instance.AutoIncrement<GuildMember>(GuildMemberRepository.Instance.Collection),
                    Role = 0,
                    PossessedRight = (int)GuildRightsBitEnum.GUILD_RIGHT_NONE,
                    PourcentageXpGiven = 5
                };

                GuildMemberRepository.Instance.Insert(guildMember);

                senderClient.SendPacket(new GuildInvitationStateRecrutedMessage((uint)SocialGroupInvitationStateEnum.SOCIAL_GROUP_INVITATION_OK));
            }
            else
            {
                senderClient.SendPacket(new GuildInvitationStateRecrutedMessage((uint)SocialGroupInvitationStateEnum.SOCIAL_GROUP_INVITATION_CANCELED));
            }

            GuildManager.Instance.RemoveGuildInvitation(client.ActiveCharacter);
        }

        [PacketId(GuildKickRequestMessage.Id)]
        public void GuildKickRequestMessageFrame(WorldClient client, GuildKickRequestMessage guildKickRequestMessage)
        {

            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;

            var target = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.CharacterId == guildKickRequestMessage.kickedId);

            if (target == null)
                return;


            var activeCharacterMember = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character.Id == client.ActiveCharacter.Id);

            //si j'ai les droit de kick un membre de la guilde et que se membre n'est pas moi
            if (activeCharacterMember != null && target.Id != activeCharacterMember.Id && activeCharacterMember.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_BAN_MEMBERS])
            {
                //delete le member
                WorldManager.Instance.GetClientFromCharacter(target.Character).SendPacket(new GuildInformationsGeneralMessage());

                client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(activeCharacterMember.Guild)));
                DatabaseManager.Instance.Delete<GuildMember>(GuildMemberRepository.Instance.Collection, target);
            }
            else if(activeCharacterMember != null && target.Id == activeCharacterMember.Id && client.ActiveCharacter.Id != client.ActiveCharacter.Guild.OwnerCharacterId) //si je m'auto kick
            {
                //delete le member
                DatabaseManager.Instance.Delete<GuildMember>(GuildMemberRepository.Instance.Collection, activeCharacterMember);
                //GuildMemberRepository.
                //client.SendPacket(new GuildR()); besoin de bibiche pour la suite
            }
        }

        [PacketId(GuildChangeMemberParametersMessage.Id)]
        public void GuildChangeMemberParametersMessageFrame(WorldClient client, GuildChangeMemberParametersMessage guildChangeMemberParametersMessage)
        {
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;

            var member = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.CharacterId == client.ActiveCharacter.Id);
            var target = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.CharacterId == guildChangeMemberParametersMessage.memberId);

            if(target == null)
            {
                return;
            }

            if (member.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RANKS])
            {
                target.Role = (int)guildChangeMemberParametersMessage.rank;
            }

            if(member.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RIGHTS])
            {
                target.PossessedRight = (int)guildChangeMemberParametersMessage.rights;
            }

            GuildMemberRepository.Instance.Update(target);
            client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(client.ActiveCharacter.Guild)));
        }

        [PacketId(GuildMotdSetRequestMessage.Id)]
        public void GuildMotdSetRequestMessageFrame(WorldClient client, GuildMotdSetRequestMessage guildMotdSetRequestMessage)
        {
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;


            if(client.ActiveCharacter.Id != client.ActiveCharacter.Guild.OwnerCharacterId)
            {
                client.SendPacket(new GuildMotdSetErrorMessage(1));
                return;
            }

            client.ActiveCharacter.Guild.Announce = guildMotdSetRequestMessage.content;
            client.SendPacket(new GuildMotdMessage(guildMotdSetRequestMessage.content, 1, 1, client.ActiveCharacter.Name));
        }

        [PacketId(GuildBulletinSetRequestMessage.Id)]
        public void GuildBulletinSetRequestMessageFrame(WorldClient client, GuildBulletinSetRequestMessage guildBulletinSetRequestMessage)
        {
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;

            if(client.ActiveCharacter.Id != client.ActiveCharacter.Guild.OwnerCharacterId)
            {
                client.SendPacket(new GuildBulletinSetErrorMessage(1));
                return;
            }

            client.ActiveCharacter.Guild.Bulletin = guildBulletinSetRequestMessage.content;
            client.SendPacket(new GuildBulletinMessage(guildBulletinSetRequestMessage.content, 1, 1, client.ActiveCharacter.Name, 0));
        }

        [PacketId(GuildGetInformationsMessage.Id)]
        public void GuildGetInformationsMessageFrame(WorldClient client, GuildGetInformationsMessage guildGetInformationsMessage)
        {
            var guild = client.ActiveCharacter.Guild;

            if(guild == null)
            {
                return;
            }

            switch(guildGetInformationsMessage.infoType)
            {
                case (uint)GuildInformationsTypeEnum.INFO_TAX_COLLECTOR_GUILD_ONLY:
                    client.SendPacket(new TaxCollectorListMessage(new List<Burning.DofusProtocol.Network.Types.TaxCollectorInformations>(), 1, new List<Burning.DofusProtocol.Network.Types.TaxCollectorFightersInformation>(), (uint)GuildInformationsTypeEnum.INFO_TAX_COLLECTOR_GUILD_ONLY));
                    break;
                case (uint)GuildInformationsTypeEnum.INFO_HOUSES:
                    client.SendPacket(new GuildHousesInformationMessage(new List<Burning.DofusProtocol.Network.Types.HouseInformationsForGuild>()));
                    break;
                case (uint)GuildInformationsTypeEnum.INFO_PADDOCKS:
                    client.SendPacket(new GuildInformationsPaddocksMessage(5, new List<Burning.DofusProtocol.Network.Types.PaddockContentInformations>()));
                    break;
                case (uint)GuildInformationsTypeEnum.INFO_MEMBERS:
                    client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(guild)));
                    break;
                case (uint)GuildInformationsTypeEnum.INFO_GENERAL:
                    client.SendPacket(new GuildInformationsGeneralMessage(false, (uint)guild.Level, 0, guild.Experience, 1000, (uint)guild.CreationDate, 1, 1));
                    break;
                default:
                    Console.WriteLine(guildGetInformationsMessage.infoType);
                    break;
            }
        }
    }
}
