using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerSessionConstantsMessage : NetworkMessage
  {
    public List<ServerSessionConstant> variables = new List<ServerSessionConstant>();
    public const uint Id = 6434;

    public override uint MessageId
    {
      get
      {
        return 6434;
      }
    }

    public ServerSessionConstantsMessage()
    {
    }

    public ServerSessionConstantsMessage(List<ServerSessionConstant> variables)
    {
      this.variables = variables;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.variables.Count);
      for (int index = 0; index < this.variables.Count; ++index)
      {
        writer.WriteShort((short) this.variables[index].TypeId);
        this.variables[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ServerSessionConstant instance = ProtocolTypeManager.GetInstance<ServerSessionConstant>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.variables.Add(instance);
      }
    }
  }
}
