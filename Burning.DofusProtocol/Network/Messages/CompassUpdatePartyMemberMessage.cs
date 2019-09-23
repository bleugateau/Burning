using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CompassUpdatePartyMemberMessage : CompassUpdateMessage
  {
    public new const uint Id = 5589;
    public double memberId;
    public bool active;

    public override uint MessageId
    {
      get
      {
        return 5589;
      }
    }

    public CompassUpdatePartyMemberMessage()
    {
    }

    public CompassUpdatePartyMemberMessage(
      uint type,
      MapCoordinates coords,
      double memberId,
      bool active)
      : base(type, coords)
    {
      this.memberId = memberId;
      this.active = active;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      writer.WriteBoolean(this.active);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of CompassUpdatePartyMemberMessage.memberId.");
      this.active = reader.ReadBoolean();
    }
  }
}
