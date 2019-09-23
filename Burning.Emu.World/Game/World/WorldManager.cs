using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Burning.Emu.World.Game.World
{
    public class WorldManager : SingletonManager<WorldManager>
    {

        public System.Timers.Timer timer;

        public List<WorldClient> worldClients = new List<WorldClient>();

        public WorldManager()
        {

        }

        public void Initialize()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);

            Task.Run(() => this.SaveWorld());
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            this.SaveWorld();
        }

        private void SaveWorld()
        {
            this.timer = new System.Timers.Timer(25000);
            // Hook up the Elapsed event for the timer. 
            this.timer.Elapsed += Timer_Elapsed;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }


        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (var character in CharacterRepository.Instance.List)
            {
                if (character.IsNew)
                {
                    CharacterRepository.Instance.Add(character);
                    character.IsNew = false;
                }
                else
                {
                    CharacterRepository.Update(character);
                }

                if (character.IsDeleted)
                {
                    CharacterRepository.Instance.Accessor.Delete<Character>(character);
                }
            }

            foreach(var guild in GuildRepository.Instance.List)
            {
                if(guild.IsNew)
                {
                    GuildRepository.Instance.Add(guild);
                    guild.IsNew = false;
                }
                else
                {
                    GuildRepository.Instance.Update(guild);
                }

                if(guild.IsDeleted)
                {
                    GuildRepository.Instance.Accessor.Delete<Burning.Common.Entity.Guild>(guild);
                }
            }

            
            foreach (var member in GuildMemberRepository.Instance.List)
            {
                if (member.IsNew)
                {
                    GuildMemberRepository.Instance.Add(member);
                    member.IsNew = false;
                }
                else
                {
                    GuildMemberRepository.Instance.Update(member);
                }

                if (member.IsDeleted)
                {
                    GuildMemberRepository.Instance.Accessor.Delete<GuildMember>(member);
                }
            }

            Console.WriteLine("World saved !");
        }

        public List<WorldClient> GetNearestClientsFromCharacter(Character character)
        {
            if (character == null)
                return null;

            return this.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter != character && x.ActiveCharacter.MapId == character.MapId);
        }

        public WorldClient GetClientFromCharacter(Character character)
        { 
            if (character == null)
                return null;

            return this.worldClients.Find(x => x.ActiveCharacter == character);
        }
    }
}
