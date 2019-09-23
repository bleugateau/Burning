using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccessoryPreviewRequestMessage : NetworkMessage
  {
    public List<uint> genericId = new List<uint>();
    public const uint Id = 6518;

    public override uint MessageId
    {
      get
      {
        return 6518;
      }
    }

    public AccessoryPreviewRequestMessage()
    {
    }

    public AccessoryPreviewRequestMessage(List<uint> genericId)
    {
      this.genericId = genericId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.genericId.Count);
      for (int index = 0; index < this.genericId.Count; ++index)
      {
        if (this.genericId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.genericId[index] + ") on element 1 (starting at 1) of genericId.");
        writer.WriteVarShort((short) this.genericId[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of genericId.");
        this.genericId.Add(num2);
      }
    }
  }
}
