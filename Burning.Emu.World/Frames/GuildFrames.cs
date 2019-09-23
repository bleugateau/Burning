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

            if(GuildRepository.Instance.List.Find(x => x.Name == guildCreationValidMessage.guildName && x.IsDeleted == false) != null)
            {
                client.SendPacket(new GuildCreationResultMessage((uint)SocialGroupCreationResultEnum.SOCIAL_GROUP_CREATE_ERROR_NAME_ALREADY_EXISTS));
                return;
            }

            var guild = new Guild()
            {
                Id = GuildRepository.Instance.Accessor.LastId<Guild>(GuildRepository.Instance.List) + 1,
                Name = guildCreationValidMessage.guildName,
                ownerCharacterId = client.ActiveCharacter.Id,
                Level = 1,
                Experience = 0,
                SymbolColor = guildCreationValidMessage.guildEmblem.symbolColor,
                SymbolShape = (int)guildCreationValidMessage.guildEmblem.symbolShape,
                BackgroundColor = guildCreationValidMessage.guildEmblem.backgroundColor,
                BackgroundShape = (int)guildCreationValidMessage.guildEmblem.backgroundShape,
                CreationDate = (int)(DateTime.Now - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds, //a patch pas bonne date
                IsNew = true
            };

            GuildRepository.Instance.List.Add(guild);

            var guildMember = new GuildMember(guild.Id, client.ActiveCharacter.Id)
            {
                Id = GuildMemberRepository.Instance.Accessor.LastId<GuildMember>(GuildMemberRepository.Instance.List) + 1,
                Role = 1,
                PossessedRight = 262145,
                PourcentageXpGiven = 0,
                IsNew = true
            };

            GuildMemberRepository.Instance.List.Add(guildMember);

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
            var member = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character == client.ActiveCharacter && x.IsDeleted == false);

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

            var senderClient = WorldManager.Instance.GetClientFromCharacter(CharacterRepository.Instance.List.Find(x => x.Id == client.ActiveCharacter.Id));

            if (guildInvitationAnswerMessage.accept)
            {
                var guildMember = new GuildMember(invitation.GuildId, client.ActiveCharacter.Id)
                {
                    Id = GuildMemberRepository.Instance.Accessor.LastId<GuildMember>(GuildMemberRepository.Instance.List) + 1,
                    Role = 0,
                    PossessedRight = (int)GuildRightsBitEnum.GUILD_RIGHT_NONE,
                    PourcentageXpGiven = 5,
                    IsNew = true
                };

                GuildMemberRepository.Instance.List.Add(guildMember);

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

            var target = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.CharacterId == guildKickRequestMessage.kickedId && x.IsDeleted == false);

            if (target == null)
                return;


            var activeCharacterMember = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character == client.ActiveCharacter);

            //si j'ai les droit de kick un membre de la guilde et que se membre n'est pas moi
            if (activeCharacterMember != null && target != activeCharacterMember && activeCharacterMember.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_BAN_MEMBERS])
            {
                target.IsDeleted = true;
                WorldManager.Instance.GetClientFromCharacter(target.Character).SendPacket(new GuildInformationsGeneralMessage());
                client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(target.Guild)));
            }
            else if(activeCharacterMember != null && target == activeCharacterMember && client.ActiveCharacter.Id != client.ActiveCharacter.Guild.ownerCharacterId) //si je m'auto kick
            {
                activeCharacterMember.IsDeleted = true;
                //client.SendPacket(new GuildR()); besoin de bibiche pour la suite
            }

            /*
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;

            if (client.ActiveCharacter.Guild.ownerCharacterId == client.ActiveCharacter.Id)
                return;

            client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character == client.ActiveCharacter).IsDeleted = true;

            */

            //kick qqun d'une guilde
            //1 = sois je peux kick
            //2 = sois je m'auto kick


            //client.SendPacket(new GuildInformationsGeneralMessage(false, (uint)guild.Level, 0, guild.Experience, 1000, (uint)guild.CreationDate, 1, 1));

        }

        [PacketId(GuildChangeMemberParametersMessage.Id)]
        public void GuildChangeMemberParametersMessageFrame(WorldClient client, GuildChangeMemberParametersMessage guildChangeMemberParametersMessage)
        {
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;

            var member = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.Character == client.ActiveCharacter && x.IsDeleted == false);
            var target = client.ActiveCharacter.Guild.GuildMembers.Find(x => x.CharacterId == guildChangeMemberParametersMessage.memberId);

            if(target == null)
            {
                return;
            }

            if (member.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RANKS])
            {
                target.Role = (int)guildChangeMemberParametersMessage.rank;
                client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(client.ActiveCharacter.Guild)));
            }

            if(member.GuildRightsItemCriterion[GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RIGHTS])
            {
                target.PossessedRight = (int)guildChangeMemberParametersMessage.rights;
                client.SendPacket(new GuildInformationsMembersMessage(GuildManager.Instance.GetGuildMembers(client.ActiveCharacter.Guild)));
            }
        }

        [PacketId(GuildMotdSetRequestMessage.Id)]
        public void GuildMotdSetRequestMessageFrame(WorldClient client, GuildMotdSetRequestMessage guildMotdSetRequestMessage)
        {
            if (client.ActiveCharacter == null || client.ActiveCharacter.Guild == null)
                return;


            if(client.ActiveCharacter.Id != client.ActiveCharacter.Guild.ownerCharacterId)
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

            if(client.ActiveCharacter.Id != client.ActiveCharacter.Guild.ownerCharacterId)
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
