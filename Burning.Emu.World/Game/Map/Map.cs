using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Burning.Common.Entity;
using Burning.Common.Enums;
using Burning.Common.Network;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;

namespace Burning.Emu.World.Game.Map
{
    public class Map
    {
        public int Id { get; set; }

        public List<NpcSpawn> NpcSpawnList { get; set; }

        public List<InteractiveElement> InteractiveElementList { get; set; }

        public List<StatedElement> StatedElementList { get; set; }

        public Burning.DofusProtocol.Data.D2P.Map MapData { get; set; }

        public Map(int mapId, Burning.DofusProtocol.Data.D2P.Map mapData)
        {
            this.Id = mapId;
            this.MapData = mapData;
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(mapId);
            this.InteractiveElementList = new List<InteractiveElement>(); //a fill avec la db
            this.StatedElementList = new List<StatedElement>(); //a fill avec la db
        }

        public void ReloadNpc()
        {
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(this.Id);
            Console.WriteLine("Npc from MapId {0} reloaded.", this.Id);
        }

        public void ReloadMobs()
        {
            Console.WriteLine("Mobs from MapId {0} reloaded.", this.Id);
        }
    }
}
