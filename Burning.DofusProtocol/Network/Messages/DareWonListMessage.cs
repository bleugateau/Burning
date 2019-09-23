using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareWonListMessage : NetworkMessage
  {
    public List<double> dareId = new List<double>();
    public const uint Id = 6682;

    public override uint MessageId
    {
      get
      {
        return 6682;
      }
    }

    public DareWonListMessage()
    {
    }

    public DareWonListMessage(List<double> dareId)
    {
      this.dareId = dareId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.dareId.Count);
      for (int index = 0; index < this.dareId.Count; ++index)
      {
        if (this.dareId[index] < 0.0 || this.dareId[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.dareId[index] + ") on element 1 (starting at 1) of dareId.");
        writer.WriteDouble(this.dareId[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < 0.0 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of dareId.");
        this.dareId.Add(num2);
      }
    }
  }
}
