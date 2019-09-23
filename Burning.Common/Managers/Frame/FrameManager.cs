using Burning.Common.Network;
using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network;
using Burning.DofusProtocol.Network.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Common.Managers.Frame
{
    public static class FrameManager
    {
        public static bool IsInitialized = false;

        private static List<FrameData> Methods = new List<FrameData>();

        private static Dictionary<uint, Type> MessageList = new Dictionary<uint, Type>(1000);

        private static Assembly GetAssemblyByName(string name)
        {
            return AppDomain.CurrentDomain.GetAssemblies().
                   SingleOrDefault(assembly => assembly.GetName().Name == name);
        }

        public static void Initialize(string assemblyName)
        {
            if (!IsInitialized)
            {
                //initiliaze frame

                ProtocolTypeManager.Initialize();

                Assembly assembly = GetAssemblyByName(assemblyName);
                foreach (var type in assembly.GetTypes().SelectMany(x => x.GetMethods()).Where(m => m.GetCustomAttributes(typeof(PacketId), false).Length > 0).ToArray())
                {
                    PacketId attr = (PacketId)type.GetCustomAttributes(typeof(PacketId), true)[0];
                    Type stringType = Type.GetType(type.DeclaringType.FullName + ", " + assemblyName);

                    var instance = Activator.CreateInstance(stringType, null); // instance d'une methode
                    Methods.Add(new FrameData(instance, attr.MessageId, type));
                }

                //initialize message
                assembly = GetAssemblyByName("Burning.DofusProtocol");
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Namespace == null || !type.Namespace.Contains("Burning.DofusProtocol.Network.Messages"))
                        continue;

                    object testInstance = Activator.CreateInstance(type);
                    var getId = type.GetMethod("get_MessageId").Invoke(testInstance, null);

                    if (getId != null)
                    {
                        try
                        {
                            if (!MessageList.ContainsKey((uint)getId))
                            {
                                MessageList.Add((uint)getId, type);
                            }
                        }
                        catch (Exception ex)
                        {}
                    }
                }



                IsInitialized = true;
                Console.WriteLine("Frame initialized !");
            }
        }

        public static void Dispatch(AbstractClient client, byte[] data)
        {
            if (!IsInitialized)
                return;

            if (client == null)
                return;

            BigEndianReader reader = new BigEndianReader(data);

            while (reader.BytesAvailable >= 2)
            {
                short header = reader.ReadShort();
                uint messageId = (uint)header >> 2;
                int m_lenghtcount = header & 3;

                if (reader.BytesAvailable >= m_lenghtcount)
                {
                    if ((m_lenghtcount < 0) || (m_lenghtcount > 3))
                        throw new Exception("Malformated Message Header, invalid bytes number to read messages");
                    else
                    {
                       if (messageId != 0)
                        {
                            
                            if (MessageList.ContainsKey(messageId))
                            {
                                NetworkMessage message = (NetworkMessage)Activator.CreateInstance(MessageList[messageId]);
                                reader = new BigEndianReader(data);

                                var messagePart = new MessagePart();
                                messagePart.Build(reader, true);
                                
                                reader = new BigEndianReader(messagePart.Data);

                                Console.WriteLine("Received: {0}:{1}.", message.MessageId, message.GetType().Name);

                                message.Deserialize(reader);
                                Build(client, message);
                            }
                        }
                    }
                }
            }
        }

        private static void Build(AbstractClient client, NetworkMessage message)
        {
            foreach (var method in Methods)
            {
                if (message.MessageId == method.PacketId)
                {
                    method.Methode.Invoke(method.Instance, new object[] { client, message });
                    break;
                }
            }
        }

    }
}
