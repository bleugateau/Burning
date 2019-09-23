using Burning.Common.Managers.Frame;
using Burning.Common.Managers.Database;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using System.Linq;
using Burning.Common.Repository.Enums;
using Burning.DofusProtocol.Data.D2o;
using System.IO;
using Burning.DofusProtocol.Data.D2P;
using Burning.Emu.World.Game.Map;
using Burning.Emu.World.Game.Command;
using Burning.Emu.World.Game.World;
using Burning.Emu.World.Game.Guild;

namespace Burning.Emu.World
{
    class Program
    {
        private static List<Task> serverTaskList = new List<Task>();
        static void Main(string[] args)
        {
            FrameManager.Initialize("Burning.Emu.World");

            DbAccessor.Auth = new DatabaseManager();
            DbAccessor.Auth.Initialize("localhost", "burning", "root", "");

            DbAccessor.World = new DatabaseManager();
            DbAccessor.World.Initialize("localhost", "burning_world", "root", "");

            CharacterRepository.Instance.Initialize("characters");
            Console.WriteLine("{0} character(s) loaded", CharacterRepository.Instance.List.Count);

            GuildRepository.Instance.Initialize("guilds");
            GuildMemberRepository.Instance.Initialize("guilds_members");

            BreedRepository.Instance.Initialize("breeds");
            Console.WriteLine("{0} breed(s) loaded from d2o.", BreedRepository.Instance.List.Count);

            HeadRepository.Instance.Initialize("heads");
            Console.WriteLine("{0} head(s) loaded from d2o.", HeadRepository.Instance.List.Count);

            NpcRepository.Instance.Initialize("npcs");
            Console.WriteLine("{0} npc(s) loaded from d2o.", NpcRepository.Instance.List.Count);

            /*
            MapRepository.Instance.Initialize("maps");
            Console.WriteLine("Map lazy loading from d2p...");
            */

            MapManager.Instance.Initialize("maps");

            MapTransitionsRepository.Instance.Initialize("maps_transitions");
            Console.WriteLine("{0} map(s) transition(s) loaded from d2o.", MapTransitionsRepository.Instance.List.Count);

            ElementsEleRepository.Instance.Initialize("elements_ele");
            Console.WriteLine("{0} elements from elements.ele loaded.", ElementsEleRepository.Instance.List.Count);

            WorldServer worldServer = new WorldServer("127.0.0.1", 6666);
            serverTaskList.Add(Task.Run(() => worldServer.Start()));

            //Manager
            CommandManager.Instance.Initialize();
            GuildManager.Instance.Initialize();
            WorldManager.Instance.Initialize();

            Task.WaitAll(serverTaskList.ToArray());
        }
    }
}
