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
using Burning.Emu.World.Repository;
using Burning.Emu.World.Game.Fight.Positions;
using Burning.Emu.World.Game.Fight;
using Burning.Emu.World.Game.Fight.Effects;

namespace Burning.Emu.World
{
    class Program
    {
        private static List<Task> serverTaskList = new List<Task>();
        static void Main(string[] args)
        {
            Console.Title = "[WORLD] BurningEmu for Dofus 2.53.2 RELEASE";

            FrameManager.Initialize("Burning.Emu.World");
            DatabaseManager.Instance.Initialize("mongodb://localhost");
            
            AccountRepository.Instance.Initialize("account");
            LevelExperienceRepository.Instance.Initialize("");
            CharacterRepository.Instance.Initialize("character");
            InventoryRepository.Instance.Initialize("inventory");

            BreedRepository.Instance.Initialize("breeds");
            SpellRepository.Instance.Initialize("spells");

            HeadRepository.Instance.Initialize("heads");
            Console.WriteLine("{0} head(s) loaded from d2o.", HeadRepository.Instance.List.Count);

            GuildRepository.Instance.Initialize("guild");

            MapManager.Instance.Initialize("maps");
            FightPositionsManager.Instance.Initialize(); //map fight generator
            MonsterRepository.Instance.Initialize("monsters");

            MapTransitionsRepository.Instance.Initialize("maps_transitions");

            //Manager
            SpellEffectManager.Instance.Initialize();
            CommandManager.Instance.Initialize();
            GuildManager.Instance.Initialize();
            FightManager.Instance.Initialize();

            WorldServer worldServer = new WorldServer("127.0.0.1", 6666);
            serverTaskList.Add(Task.Run(() => worldServer.Start()));


            Task.WaitAll(serverTaskList.ToArray());
        }
    }
}
