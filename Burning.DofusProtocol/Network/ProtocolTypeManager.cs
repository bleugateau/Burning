using FlatyBot.Common.Extensions;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Burning.DofusProtocol.Network
{
  public static class ProtocolTypeManager
  {
    private static readonly Dictionary<uint, Type> types = new Dictionary<uint, Type>(200);
    private static readonly Dictionary<uint, Func<object>> typesConstructors = new Dictionary<uint, Func<object>>(200);

    public static T GetInstance<T>(ushort id) where T : class
    {
      if (!ProtocolTypeManager.types.ContainsKey((uint) id))
      {
        TypeDescriptor.GetConverter(typeof (T));
        Console.WriteLine(string.Format("Type <id:{0}> doesn't exist", (object) id));
      }
      return ProtocolTypeManager.typesConstructors[(uint) id]() as T;
    }

    public static T GetInstance<T>(uint id) where T : class
    {
      if (!ProtocolTypeManager.types.ContainsKey(id))
      {
        TypeDescriptor.GetConverter(typeof (T));
        Console.WriteLine(string.Format("Type <id:{0}> doesn't exist", (object) id));
      }
      return ProtocolTypeManager.typesConstructors[id]() as T;
    }

    public static void Initialize()
    {
      foreach (Type type in Assembly.GetAssembly(typeof (ProtocolTypeManager)).GetTypes())
      {
        if ((type.Namespace == null ? 0 : (type.Namespace.StartsWith(typeof (GameServerInformations).Namespace) ? 1 : 0)) != 0)
        {
          FieldInfo field = type.GetField("Id");
          if (field != (FieldInfo) null)
          {
            uint key = (uint) field.GetValue((object) type);
            ProtocolTypeManager.types.Add(key, type);
            ConstructorInfo constructor = type.GetConstructor(Type.EmptyTypes);
            int num = constructor == (ConstructorInfo) null ? 1 : 0;
            ProtocolTypeManager.typesConstructors.Add(key, constructor.CreateDelegate<Func<object>>());
          }
        }
      }
    }

    [Serializable]
    public class ProtocolTypeNotFoundException : Exception
    {
      public ProtocolTypeNotFoundException()
      {
      }

      public ProtocolTypeNotFoundException(string message)
        : base(message)
      {
      }

      public ProtocolTypeNotFoundException(string message, Exception inner)
        : base(message, inner)
      {
      }

      protected ProtocolTypeNotFoundException(SerializationInfo info, StreamingContext context)
        : base(info, context)
      {
      }
    }
  }
}
