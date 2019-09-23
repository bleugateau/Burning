using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MountFeedRequestMessage : NetworkMessage
  {
    public const uint Id = 6189;
    public uint mountUid;
    public int mountLocation;
    public uint mountFoodUid;
    public uint quantity;

    public override uint MessageId
    {
      get
      {
        return 6189;
      }
    }

    public MountFeedRequestMessage()
    {
    }

    public MountFeedRequestMessage(
      uint mountUid,
      int mountLocation,
      uint mountFoodUid,
      uint quantity)
    {
      this.mountUid = mountUid;
      this.mountLocation = mountLocation;
      this.mountFoodUid = mountFoodUid;
      this.quantity = quantity;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mountUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.mountUid + ") on element mountUid.");
      writer.WriteVarInt((int) this.mountUid);
      writer.WriteByte((byte) this.mountLocation);
      if (this.mountFoodUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.mountFoodUid + ") on element mountFoodUid.");
      writer.WriteVarInt((int) this.mountFoodUid);
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element quantity.");
      writer.WriteVarInt((int) this.quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mountUid = reader.ReadVarUhInt();
      if (this.mountUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.mountUid + ") on element of MountFeedRequestMessage.mountUid.");
      this.mountLocation = (int) reader.ReadByte();
      this.mountFoodUid = reader.ReadVarUhInt();
      if (this.mountFoodUid < 0U)
        throw new Exception("Forbidden value (" + (object) this.mountFoodUid + ") on element of MountFeedRequestMessage.mountFoodUid.");
      this.quantity = reader.ReadVarUhInt();
      if (this.quantity < 0U)
        throw new Exception("Forbidden value (" + (object) this.quantity + ") on element of MountFeedRequestMessage.quantity.");
    }
  }
}
