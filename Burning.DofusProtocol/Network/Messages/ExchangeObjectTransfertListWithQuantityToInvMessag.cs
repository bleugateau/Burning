using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeObjectTransfertListWithQuantityToInvMessage : NetworkMessage
  {
    public List<uint> ids = new List<uint>();
    public List<uint> qtys = new List<uint>();
    public const uint Id = 6470;

    public override uint MessageId
    {
      get
      {
        return 6470;
      }
    }

    public ExchangeObjectTransfertListWithQuantityToInvMessage()
    {
    }

    public ExchangeObjectTransfertListWithQuantityToInvMessage(List<uint> ids, List<uint> qtys)
    {
      this.ids = ids;
      this.qtys = qtys;
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
      writer.WriteShort((short) this.qtys.Count);
      for (int index = 0; index < this.qtys.Count; ++index)
      {
        if (this.qtys[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.qtys[index] + ") on element 2 (starting at 1) of qtys.");
        writer.WriteVarInt((int) this.qtys[index]);
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
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of qtys.");
        this.qtys.Add(num2);
      }
    }
  }
}
