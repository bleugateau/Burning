using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EntityTalkMessage : NetworkMessage
  {
    public List<string> parameters = new List<string>();
    public const uint Id = 6110;
    public double entityId;
    public uint textId;

    public override uint MessageId
    {
      get
      {
        return 6110;
      }
    }

    public EntityTalkMessage()
    {
    }

    public EntityTalkMessage(double entityId, uint textId, List<string> parameters)
    {
      this.entityId = entityId;
      this.textId = textId;
      this.parameters = parameters;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.entityId < -9.00719925474099E+15 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element entityId.");
      writer.WriteDouble(this.entityId);
      if (this.textId < 0U)
        throw new Exception("Forbidden value (" + (object) this.textId + ") on element textId.");
      writer.WriteVarShort((short) this.textId);
      writer.WriteShort((short) this.parameters.Count);
      for (int index = 0; index < this.parameters.Count; ++index)
        writer.WriteUTF(this.parameters[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.entityId = reader.ReadDouble();
      if (this.entityId < -9.00719925474099E+15 || this.entityId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.entityId + ") on element of EntityTalkMessage.entityId.");
      this.textId = (uint) reader.ReadVarUhShort();
      if (this.textId < 0U)
        throw new Exception("Forbidden value (" + (object) this.textId + ") on element of EntityTalkMessage.textId.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.parameters.Add(reader.ReadUTF());
    }
  }
}
