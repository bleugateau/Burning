using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NotificationByServerMessage : NetworkMessage
  {
    public List<string> parameters = new List<string>();
    public const uint Id = 6103;
    public uint id;
    public bool forceOpen;

    public override uint MessageId
    {
      get
      {
        return 6103;
      }
    }

    public NotificationByServerMessage()
    {
    }

    public NotificationByServerMessage(uint id, List<string> parameters, bool forceOpen)
    {
      this.id = id;
      this.parameters = parameters;
      this.forceOpen = forceOpen;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarShort((short) this.id);
      writer.WriteShort((short) this.parameters.Count);
      for (int index = 0; index < this.parameters.Count; ++index)
        writer.WriteUTF(this.parameters[index]);
      writer.WriteBoolean(this.forceOpen);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadVarUhShort();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of NotificationByServerMessage.id.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
        this.parameters.Add(reader.ReadUTF());
      this.forceOpen = reader.ReadBoolean();
    }
  }
}
