using Burning.Common.Managers.Frame;
using Burning.Common.Managers.Database;
using Burning.Emu.Network;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Burning.Common.Repository;

namespace Burning.Emu
{
    class Program
    {
        private static List<Task> serverTaskList = new List<Task>();
        static void Main(string[] args)
        {
            Console.Title = "[REALM] BurningEmu for Dofus 2.53.2 RELEASE";

            FrameManager.Initialize("Burning.Emu");

            DatabaseManager.Instance.Initialize("mongodb://localhost");

            AccountRepository.Instance.Initialize("account");

            AuthServer authServer = new AuthServer("127.0.0.1", 6897);
            serverTaskList.Add(Task.Run(() => authServer.Start()));
            

            Task.WaitAll(serverTaskList.ToArray());
        }
    }
}
