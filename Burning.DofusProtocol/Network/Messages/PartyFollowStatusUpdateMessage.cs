using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyFollowStatusUpdateMessage : AbstractPartyMessage
  {
    public new const uint Id = 5581;
    public bool success;
    public bool isFollowed;
    public double followedId;

    public override uint MessageId
    {
      get
      {
        return 5581;
      }
    }

    public PartyFollowStatusUpdateMessage()
    {
    }

    public PartyFollowStatusUpdateMessage(
      uint partyId,
      bool success,
      bool isFollowed,
      double followedId)
      : base(partyId)
    {
      this.success = success;
      this.isFollowed = isFollowed;
      this.followedId = followedId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.success), (byte) 1, this.isFollowed);
      writer.WriteByte((byte) num);
      if (this.followedId < 0.0 || this.followedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.followedId + ") on element followedId.");
      writer.WriteVarLong((long) this.followedId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.success = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.isFollowed = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.followedId = (double) reader.ReadVarUhLong();
      if (this.followedId < 0.0 || this.followedId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.followedId + ") on element of PartyFollowStatusUpdateMessage.followedId.");
    }
  }
}
