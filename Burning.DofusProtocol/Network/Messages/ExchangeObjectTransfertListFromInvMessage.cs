using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectTransfertListFromInvMessage : NetworkMessage
  {
    public List<uint> ids = new List<uint>();
    public const uint Id = 6183;

    public override uint MessageId
    {
      get
      {
        return 6183;
      }
    }

    public ExchangeObjectTransfertListFromInvMessage()
    {
    }

    public ExchangeObjectTransfertListFromInvMessage(List<uint> ids)
    {
      this.ids = ids;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.ids.Count);
      for (int index = 0; index < this.ids.Count; ++index)
      {
        if (this.ids[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ids[index] + ") on element 1 (starting at 1) of ids.");
        writer.WriteVarInt((int) this.ids[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ids.");
        this.ids.Add(num2);
      }
    }
  }
}
