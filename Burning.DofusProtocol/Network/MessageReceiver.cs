using FlatyBot.Common.Extensions;
using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;

namespace Burning.DofusProtocol.Network
{
  public static class MessageReceiver
  {
    private static readonly Dictionary<uint, Func<NetworkMessage>> m_constructors = new Dictionary<uint, Func<NetworkMessage>>(800);
    private static readonly Dictionary<uint, Type> m_messages = new Dictionary<uint, Type>(800);

    public static NetworkMessage BuildMessage(uint id, IDataReader reader)
    {
      Stopwatch stopwatch = Stopwatch.StartNew();
      NetworkMessage networkMessage1;
      try
      {
        if (!MessageReceiver.m_messages.ContainsKey(id))
          throw new MessageReceiver.MessageNotFoundException(string.Format("NetworkMessage <id:{0}> doesn't exist", (object) id));
        NetworkMessage networkMessage2 = MessageReceiver.m_constructors[id]();
        if (networkMessage2 == null)
          throw new MessageReceiver.MessageNotFoundException(string.Format("Constructors[{0}] (delegate {1}) does not exist", (object) id, (object) MessageReceiver.m_messages[id]));
        networkMessage2.Unpack(reader);
        networkMessage1 = networkMessage2;
      }
      catch (Exception ex)
      {
        Console.WriteLine(string.Format("Can't BuildMessage for id {0} ({1}).", (object) id, (object) ex.Message));
        networkMessage1 = (NetworkMessage) null;
      }
      stopwatch.Stop();
      return networkMessage1;
    }

    public static Type GetMessageType(uint id)
    {
      if (!MessageReceiver.m_messages.ContainsKey(id))
        throw new MessageReceiver.MessageNotFoundException(string.Format("NetworkMessage <id:{0}> doesn't exist", (object) id));
      return MessageReceiver.m_messages[id];
    }

    public static void Initialize()
    {
      foreach (Type type in Assembly.GetAssembly(typeof (MessageReceiver)).GetTypes())
      {
        if (type.IsSubclassOf(typeof (NetworkMessage)))
        {
          FieldInfo field = type.GetField("Id");
          if (field != (FieldInfo) null)
          {
            uint key = (uint) field.GetValue((object) type);
            if (MessageReceiver.m_messages.ContainsKey(key))
              throw new AmbiguousMatchException(string.Format("MessageReceiver() => {0} item is already in the dictionary, old type is : {1}, new type is  {2}", (object) key, (object) MessageReceiver.m_messages[key], (object) type));
            MessageReceiver.m_messages.Add(key, type);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            int num = constructor == (ConstructorInfo) null ? 1 : 0;
            MessageReceiver.m_constructors.Add(key, constructor.CreateDelegate<Func<NetworkMessage>>());
          }
        }
      }
    }

    [Serializable]
    public class MessageNotFoundException : Exception
    {
      public MessageNotFoundException()
      {
      }

      public MessageNotFoundException(string message)
        : base(message)
      {
      }

      public MessageNotFoundException(string message, Exception inner)
        : base(message, inner)
      {
      }

      protected MessageNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
      }
    }
  }
}
