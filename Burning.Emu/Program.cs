using Burning.Common.Managers.Frame;
using Burning.Common.Managers.Database;
using Burning.Emu.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Burning.Emu
{
    class Program
    {
        private static List<Task> serverTaskList = new List<Task>();
        static void Main(string[] args)
        {
            Console.Title = "BurningEmu for Dofus 2.52.14 RELEASE";

            FrameManager.Initialize("Burning.Emu");

            DbAccessor.Auth = new DatabaseManager();
            DbAccessor.Auth.Initialize("localhost", "burning", "root", "");

            /*
            DbAccessor.World = new DatabaseManager();
            DbAccessor.World.Initialize("localhost", "burning_world", "root", "");
            */
            
            AuthServer authServer = new AuthServer("127.0.0.1", 6897);
            serverTaskList.Add(Task.Run(() => authServer.Start()));
            

            Task.WaitAll(serverTaskList.ToArray());
        }
    }
}
