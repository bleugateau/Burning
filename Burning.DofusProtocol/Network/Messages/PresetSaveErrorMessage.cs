using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetSaveErrorMessage : NetworkMessage
  {
    public const uint Id = 6762;
    public int presetId;
    public uint code;

    public override uint MessageId
    {
      get
      {
        return 6762;
      }
    }

    public PresetSaveErrorMessage()
    {
    }

    public PresetSaveErrorMessage(int presetId, uint code)
    {
      this.presetId = presetId;
      this.code = code;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.presetId);
      writer.WriteByte((byte) this.code);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.presetId = (int) reader.ReadShort();
      this.code = (uint) reader.ReadByte();
      if (this.code < 0U)
        throw new Exception("Forbidden value (" + (object) this.code + ") on element of PresetSaveErrorMessage.code.");
    }
  }
}
