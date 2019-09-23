using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
  {
    public List<double> actorIds = new List<double>();
    public new const uint Id = 5691;

    public override uint MessageId
    {
      get
      {
        return 5691;
      }
    }

    public EmotePlayMassiveMessage()
    {
    }

    public EmotePlayMassiveMessage(uint emoteId, double emoteStartTime, List<double> actorIds)
      : base(emoteId, emoteStartTime)
    {
      this.actorIds = actorIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.actorIds.Count);
      for (int index = 0; index < this.actorIds.Count; ++index)
      {
        if (this.actorIds[index] < -9.00719925474099E+15 || this.actorIds[index] > 9.00719925474099E+15)
          throw new Exception("Forbidden value (" + (object) this.actorIds[index] + ") on element 1 (starting at 1) of actorIds.");
        writer.WriteDouble(this.actorIds[index]);
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
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of actorIds.");
        this.actorIds.Add(num2);
      }
    }
  }
}
