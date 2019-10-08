using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Command
{
    public static class CommandManager
    {
        private static Dictionary<string, CommandData> CommandsList = new Dictionary<string, CommandData>();


        public static void Initialize()
        {
            Assembly assembly = typeof(Command).Assembly;
            foreach (var type in assembly.GetTypes().SelectMany(x => x.GetConstructors()).Where(m => m.GetCustomAttributes(typeof(CommandAttribute), false).Length > 0).ToArray())
            {
                CommandAttribute attr = (CommandAttribute)type.GetCustomAttributes(typeof(CommandAttribute), true)[0];
                Type stringType = Type.GetType(type.DeclaringType.FullName + ", " + assembly.GetName());

                List<Type> paramTypes = new List<Type>();
                List<object> objectParam = new List<object>();

                foreach(var param in type.GetParameters())
                {
                    paramTypes.Add(param.ParameterType);
                    objectParam.Add(null);
                    //Console.WriteLine(param.Name);
                }

                ConstructorInfo ctor = stringType.GetConstructor(paramTypes.ToArray());
                object instance = ctor.Invoke(objectParam.ToArray());

                CommandsList.Add(attr.CommandeName, new CommandData(instance, attr.CommandeName, type));
            }

            Console.WriteLine("{0} command(s) initialized.", CommandsList.Count);
        }

        public static void GetCommandeFromContent(string content, WorldClient client)
        {

            var command = CommandsList.FirstOrDefault(x => content.Contains(x.Key));
            if(command.Key != null && content.StartsWith("."))
            {
                command.Value.Methode.Invoke(command.Value.Instance, new object[] { content, client });
                command.Value.Methode.DeclaringType.GetMethod("RunCommand").Invoke(command.Value.Instance, null);
            }
            else
            {
                client.SendPacket(new ChatServerMessage(10, "Commande inconnue, faites .help pour la liste des commandes.", 0, "", 0, "", "", 0));
            }
        }
    }
}
