using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeHandleMountsMessage : NetworkMessage
  {
    public List<uint> ridesId = new List<uint>();
    public const uint Id = 6752;
    public int actionType;

    public override uint MessageId
    {
      get
      {
        return 6752;
      }
    }

    public ExchangeHandleMountsMessage()
    {
    }

    public ExchangeHandleMountsMessage(int actionType, List<uint> ridesId)
    {
      this.actionType = actionType;
      this.ridesId = ridesId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.actionType);
      writer.WriteShort((short) this.ridesId.Count);
      for (int index = 0; index < this.ridesId.Count; ++index)
      {
        if (this.ridesId[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ridesId[index] + ") on element 2 (starting at 1) of ridesId.");
        writer.WriteVarInt((int) this.ridesId[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.actionType = (int) reader.ReadByte();
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = reader.ReadVarUhInt();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ridesId.");
        this.ridesId.Add(num2);
      }
    }
  }
}
