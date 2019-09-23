using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightTurnListMessage : NetworkMessage
  {
    public List<double> ids = new List<double>();
    public List<double> deadsIds = new List<double>();
    public const uint Id = 713;

    public override uint MessageId
    {
      get
      {
        return 713;
      }
    }

    public GameFightTurnListMessage()
    {
    }

    public GameFightTurnListMessage(List<double> ids, List<double> deadsIds)
    {
      this.ids = ids;
      this.deadsIds = deadsIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.ids.Count);
      for (int index = 0; index < this.ids.Count; ++index)
      {
        if (this.ids[index] < -9.00719925474099E+15 || this.ids[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.ids[index] + ") on element 1 (starting at 1) of ids.");
        writer.WriteDouble(this.ids[index]);
      }
      writer.WriteShort((short) this.deadsIds.Count);
      for (int index = 0; index < this.deadsIds.Count; ++index)
      {
        if (this.deadsIds[index] < -9.00719925474099E+15 || this.deadsIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.deadsIds[index] + ") on element 2 (starting at 1) of deadsIds.");
        writer.WriteDouble(this.deadsIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of ids.");
        this.ids.Add(num2);
      }
      uint num3 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num3; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of deadsIds.");
        this.deadsIds.Add(num2);
      }
    }
  }
}
