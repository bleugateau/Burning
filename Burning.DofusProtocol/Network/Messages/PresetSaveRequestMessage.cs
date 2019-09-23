using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetSaveRequestMessage : NetworkMessage
  {
    public const uint Id = 6761;
    public int presetId;
    public uint symbolId;
    public bool updateData;

    public override uint MessageId
    {
      get
      {
        return 6761;
      }
    }

    public PresetSaveRequestMessage()
    {
    }

    public PresetSaveRequestMessage(int presetId, uint symbolId, bool updateData)
    {
      this.presetId = presetId;
      this.symbolId = symbolId;
      this.updateData = updateData;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetId);
      if (this.symbolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbolId + ") on element symbolId.");
      writer.WriteByte((byte) this.symbolId);
      writer.WriteBoolean(this.updateData);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.presetId = (int) reader.ReadShort();
      this.symbolId = (uint) reader.ReadByte();
      if (this.symbolId < 0U)
        throw new Exception("Forbidden value (" + (object) this.symbolId + ") on element of PresetSaveRequestMessage.symbolId.");
      this.updateData = reader.ReadBoolean();
    }
  }
}
