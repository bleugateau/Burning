using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PresetUseResultWithMissingIdsMessage : PresetUseResultMessage
  {
    public List<uint> missingIds = new List<uint>();
    public new const uint Id = 6757;

    public override uint MessageId
    {
      get
      {
        return 6757;
      }
    }

    public PresetUseResultWithMissingIdsMessage()
    {
    }

    public PresetUseResultWithMissingIdsMessage(int presetId, uint code, List<uint> missingIds)
      : base(presetId, code)
    {
      this.missingIds = missingIds;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.missingIds.Count);
      for (int index = 0; index < this.missingIds.Count; ++index)
      {
        if (this.missingIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.missingIds[index] + ") on element 1 (starting at 1) of missingIds.");
        writer.WriteVarShort((short) this.missingIds[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadVarUhShort();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of missingIds.");
        this.missingIds.Add(num2);
      }
    }
  }
}
