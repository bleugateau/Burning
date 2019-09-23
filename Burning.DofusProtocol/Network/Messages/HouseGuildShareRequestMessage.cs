using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HouseGuildShareRequestMessage : NetworkMessage
  {
    public const uint Id = 5704;
    public uint houseId;
    public uint instanceId;
    public bool enable;
    public uint rights;

    public override uint MessageId
    {
      get
      {
        return 5704;
      }
    }

    public HouseGuildShareRequestMessage()
    {
    }

    public HouseGuildShareRequestMessage(uint houseId, uint instanceId, bool enable, uint rights)
    {
      this.houseId = houseId;
      this.instanceId = instanceId;
      this.enable = enable;
      this.rights = rights;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element houseId.");
      writer.WriteVarInt((int) this.houseId);
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element instanceId.");
      writer.WriteInt((int) this.instanceId);
      writer.WriteBoolean(this.enable);
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element rights.");
      writer.WriteVarInt((int) this.rights);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.houseId = reader.ReadVarUhInt();
      if (this.houseId < 0U)
        throw new Exception("Forbidden value (" + (object) this.houseId + ") on element of HouseGuildShareRequestMessage.houseId.");
      this.instanceId = (uint) reader.ReadInt();
      if (this.instanceId < 0U)
        throw new Exception("Forbidden value (" + (object) this.instanceId + ") on element of HouseGuildShareRequestMessage.instanceId.");
      this.enable = reader.ReadBoolean();
      this.rights = reader.ReadVarUhInt();
      if (this.rights < 0U)
        throw new Exception("Forbidden value (" + (object) this.rights + ") on element of HouseGuildShareRequestMessage.rights.");
    }
  }
}
