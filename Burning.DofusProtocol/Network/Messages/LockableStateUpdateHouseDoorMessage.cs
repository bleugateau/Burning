using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableStateUpdateHouseDoorMessage : LockableStateUpdateAbstractMessage
  {
    public new const uint Id = 5668;
    public uint houseId;
    public uint instanceId;
    public bool secondHand;

    public override uint MessageId
    {
      get
      {
        return 5668;
      }
    }

    public LockableStateUpdateHouseDoorMessage()
    {
    }

    public LockableStateUpdateHouseDoorMessage(
      bool locked,
      uint houseId,
      uint instanceId,
      bool secondHand)
      : base(locked)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.secondHand = secondHand;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.secondHand);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of LockableStateUpdateHouseDoorMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of LockableStateUpdateHouseDoorMessage.instanceId.");
      this.secondHand = reader.ReadBoolean();
    }
  }
}
