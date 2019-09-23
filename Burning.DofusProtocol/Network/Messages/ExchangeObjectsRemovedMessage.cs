using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
  {
    public List<uint> objectUID = new List<uint>();
    public new const uint Id = 6532;

    public override uint MessageId
    {
      get
      {
        return 6532;
      }
    }

    public ExchangeObjectsRemovedMessage()
    {
    }

    public ExchangeObjectsRemovedMessage(bool remote, List<uint> objectUID)
      : base(remote)
    {
      this.objectUID = objectUID;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.objectUID.Count);
      for (int index = 0; index < this.objectUID.Count; ++index)
      {
        if (this.objectUID[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.objectUID[index] + ") on element 1 (starting at 1) of objectUID.");
        writer.WriteVarInt((int) this.objectUID[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of objectUID.");
        this.objectUID.Add(num2);
      }
    }
  }
}
