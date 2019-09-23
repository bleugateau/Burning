using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightTackledMessage : AbstractGameActionMessage
  {
    public List<double> tacklersIds = new List<double>();
    public new const uint Id = 1004;

    public override uint MessageId
    {
      get
      {
        return 1004;
      }
    }

    public GameActionFightTackledMessage()
    {
    }

    public GameActionFightTackledMessage(uint actionId, double sourceId, List<double> tacklersIds)
      : base(actionId, sourceId)
    {
      this.tacklersIds = tacklersIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.tacklersIds.Count);
      for (int index = 0; index < this.tacklersIds.Count; ++index)
      {
        if (this.tacklersIds[index] < -9.00719925474099E+15 || this.tacklersIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.tacklersIds[index] + ") on element 1 (starting at 1) of tacklersIds.");
        writer.WriteDouble(this.tacklersIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        double num2 = reader.ReadDouble();
        if (num2 < -9.00719925474099E+15 || num2 > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of tacklersIds.");
        this.tacklersIds.Add(num2);
      }
    }
  }
}
