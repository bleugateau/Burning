using Burning.Common.Entity;
using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Entity;
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
            //todo
        }

        public void UpdateRolePlayActor(Character character)
        {
            foreach (var otherCharacter in this.GetNearestClientsFromCharacter(character))
            {
                otherCharacter.SendPacket(new GameRolePlayShowActorMessage(character.GetGameRolePlayCharacterInformations()));
            }
        }

        public List<WorldClient> GetClientsOnMapId(int mapId)
        {
            return this.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.MapId == mapId);
        }

        public List<WorldClient> GetNearestClientsFromCharacter(Character character)
        {
            if (character == null)
                return null;

            return this.worldClients.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.Id != character.Id && x.ActiveCharacter.MapId == character.MapId);
        }

        public WorldClient GetClientFromCharacter(Character character)
        { 
            if (character == null)
                return null;

            return this.worldClients.Find(x => x.ActiveCharacter != null && x.ActiveCharacter.Id == character.Id);
        }
    }
}
