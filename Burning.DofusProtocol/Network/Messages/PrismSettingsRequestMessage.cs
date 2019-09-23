using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismSettingsRequestMessage : NetworkMessage
  {
    public const uint Id = 6437;
    public uint subAreaId;
    public uint startDefenseTime;

    public override uint MessageId
    {
      get
      {
        return 6437;
      }
    }

    public PrismSettingsRequestMessage()
    {
    }

    public PrismSettingsRequestMessage(uint subAreaId, uint startDefenseTime)
    {
      this.subAreaId = subAreaId;
      this.startDefenseTime = startDefenseTime;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element subAreaId.");
      writer.WriteVarShort((short) this.subAreaId);
      if (this.startDefenseTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.startDefenseTime + ") on element startDefenseTime.");
      writer.WriteByte((byte) this.startDefenseTime);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.subAreaId = (uint) reader.ReadVarUhShort();
      if (this.subAreaId < 0U)
        throw new Exception("Forbidden value (" + (object) this.subAreaId + ") on element of PrismSettingsRequestMessage.subAreaId.");
      this.startDefenseTime = (uint) reader.ReadByte();
      if (this.startDefenseTime < 0U)
        throw new Exception("Forbidden value (" + (object) this.startDefenseTime + ") on element of PrismSettingsRequestMessage.startDefenseTime.");
    }
  }
}
