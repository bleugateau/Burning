using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Game.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Guild
{
    public class GuildManager : SingletonManager<GuildManager>
    {

        private List<GuildInvitation> GuildInvitations = new List<GuildInvitation>();

        public GuildManager() { }

        public void Initialize()
        {
            //this.GuildInvitations = new List<GuildInvitation>();
        }

        public List<Burning.DofusProtocol.Network.Types.GuildMember> GetGuildMembers(Burning.Emu.World.Entity.Guild guild)
        {
            List<Burning.DofusProtocol.Network.Types.GuildMember> guildMembers = new List<DofusProtocol.Network.Types.GuildMember>();
            foreach (var member in guild.GuildMembers)
            {
                int connected = WorldManager.Instance.GetClientFromCharacter(member.Character) != null ? 1 : 0;

                guildMembers.Add(new DofusProtocol.Network.Types.GuildMember(member.Character.Id, member.Character.Name, (uint)member.Character.Level, member.Character.Breed, member.Character.Sex,
                    (uint)member.Role, 0, (uint)member.PourcentageXpGiven, (uint)member.PossessedRight, (uint)connected, 2, 13130, 1, (uint)member.Character.AccountId, 0, new Burning.DofusProtocol.Network.Types.PlayerStatus(10), false));
            }

            return guildMembers;
        }

        public void AddGuildInvitations(GuildInvitation guildInvitation)
        {
            //on recherche si une invitation pour cette personne existe déjà
            var oldInvitation = this.GuildInvitations.Find(x => x.TargetId == guildInvitation.TargetId);
            if (oldInvitation != null)
                this.GuildInvitations.Remove(oldInvitation); //sinon on la remove

            this.GuildInvitations.Add(guildInvitation); //ici on l'ajoute dans la liste
        }

        public void RemoveGuildInvitation(Character character)
        {
            var invitation = this.GuildInvitations.Find(x => x.TargetId == character.Id);

            if (invitation != null)
                this.GuildInvitations.Remove(invitation);
        }

        public GuildInvitation GetGuildInvitation(Character character)
        {
            return this.GuildInvitations.Find(x => x.TargetId == character.Id);
        }
    }
}
