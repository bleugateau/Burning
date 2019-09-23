using System;
using System.Collections.Generic;
using System.Text;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Enums;

//GuildWrapper.as
namespace Burning.Common.Managers.Guild
{
    public static class GuildRightsManager
    {
        public static Dictionary<GuildRightsBitEnum, bool> GetRights(uint _memberRightsNumber)
        {
            Dictionary<GuildRightsBitEnum, bool> GuildRights = new Dictionary<GuildRightsBitEnum, bool>();

            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_BOSS, isBoss(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_MANAGE_GUILD_BOOSTS, manageGuildBoosts(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RIGHTS, manageRights(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_INVITE_NEW_MEMBERS, inviteNewMembers(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_BAN_MEMBERS, banMembers(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_MANAGE_XP_CONTRIBUTION, manageXPContribution(_memberRightsNumber));
            GuildRights.Add(GuildRightsBitEnum.GUILD_RIGHT_MANAGE_RANKS, manageRanks(_memberRightsNumber));

            return GuildRights;
        }

        public static bool isBoss(uint _memberRightsNumber)
        {
            return (1 & _memberRightsNumber) > 0;
        }

        public static bool manageGuildBoosts(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || manageRights(_memberRightsNumber) || (2 & _memberRightsNumber) > 0;
        }

        public static bool manageRights(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || (4 & _memberRightsNumber) > 0;
        }

        public static bool inviteNewMembers(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || manageRights(_memberRightsNumber) || (8 & _memberRightsNumber) > 0;
        }

        public static bool banMembers(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || manageRights(_memberRightsNumber) || (16 & _memberRightsNumber) > 0;
        }

        public static bool manageXPContribution(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || manageRights(_memberRightsNumber) || (32 & _memberRightsNumber) > 0;
        }

        public static bool manageRanks(uint _memberRightsNumber)
        {
            return isBoss(_memberRightsNumber) || manageRights(_memberRightsNumber) || (64 & _memberRightsNumber) > 0;
        }

    }
}
