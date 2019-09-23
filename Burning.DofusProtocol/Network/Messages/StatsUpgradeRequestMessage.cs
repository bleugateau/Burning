using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StatsUpgradeRequestMessage : NetworkMessage
  {
    public const uint Id = 5610;
    public bool useAdditionnal;
    public uint statId;
    public uint boostPoint;

    public override uint MessageId
    {
      get
      {
        return 5610;
      }
    }

    public StatsUpgradeRequestMessage()
    {
    }

    public StatsUpgradeRequestMessage(bool useAdditionnal, uint statId, uint boostPoint)
    {
      this.useAdditionnal = useAdditionnal;
      this.statId = statId;
      this.boostPoint = boostPoint;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.useAdditionnal);
      writer.WriteByte((byte) this.statId);
      if (this.boostPoint < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostPoint + ") on element boostPoint.");
      writer.WriteVarShort((short) this.boostPoint);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.useAdditionnal = reader.ReadBoolean();
      this.statId = (uint) reader.ReadByte();
      if (this.statId < 0U)
        throw new Exception("Forbidden value (" + (object) this.statId + ") on element of StatsUpgradeRequestMessage.statId.");
      this.boostPoint = (uint) reader.ReadVarUhShort();
      if (this.boostPoint < 0U)
        throw new Exception("Forbidden value (" + (object) this.boostPoint + ") on element of StatsUpgradeRequestMessage.boostPoint.");
    }
  }
}
