using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ObjectAveragePricesMessage : NetworkMessage
  {
    public List<uint> ids = new List<uint>();
    public List<double> avgPrices = new List<double>();
    public const uint Id = 6335;

    public override uint MessageId
    {
      get
      {
        return 6335;
      }
    }

    public ObjectAveragePricesMessage()
    {
    }

    public ObjectAveragePricesMessage(List<uint> ids, List<double> avgPrices)
    {
      this.ids = ids;
      this.avgPrices = avgPrices;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.ids.Count);
      for (int index = 0; index < this.ids.Count; ++index)
      {
        if (this.ids[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.ids[index] + ") on element 1 (starting at 1) of ids.");
        writer.WriteVarShort((short) this.ids[index]);
      }
      writer.WriteShort((short) this.avgPrices.Count);
      for (int index = 0; index < this.avgPrices.Count; ++index)
      {
        if (this.avgPrices[index] < 0.0 || this.avgPrices[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.avgPrices[index] + ") on element 2 (starting at 1) of avgPrices.");
        writer.WriteVarLong((long) this.avgPrices[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ids.");
        this.ids.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        double num2 = (double) reader.ReadVarUhLong();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of avgPrices.");
        this.avgPrices.Add(num2);
      }
    }
  }
}
