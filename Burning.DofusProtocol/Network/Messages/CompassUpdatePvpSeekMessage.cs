using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CompassUpdatePvpSeekMessage : CompassUpdateMessage
  {
    public new const uint Id = 6013;
    public double memberId;
    public string memberName;

    public override uint MessageId
    {
      get
      {
        return 6013;
      }
    }

    public CompassUpdatePvpSeekMessage()
    {
    }

    public CompassUpdatePvpSeekMessage(
      uint type,
      MapCoordinates coords,
      double memberId,
      string memberName)
      : base(type, coords)
    {
      this.memberId = memberId;
      this.memberName = memberName;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element memberId.");
      writer.WriteVarLong((long) this.memberId);
      writer.WriteUTF(this.memberName);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.memberId = (double) reader.ReadVarUhLong();
      if (this.memberId < 0.0 || this.memberId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.memberId + ") on element of CompassUpdatePvpSeekMessage.memberId.");
      this.memberName = reader.ReadUTF();
    }
  }
}
