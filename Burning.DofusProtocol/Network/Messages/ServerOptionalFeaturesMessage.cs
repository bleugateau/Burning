using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ServerOptionalFeaturesMessage : NetworkMessage
  {
    public List<uint> features = new List<uint>();
    public const uint Id = 6305;

    public override uint MessageId
    {
      get
      {
        return 6305;
      }
    }

    public ServerOptionalFeaturesMessage()
    {
    }

    public ServerOptionalFeaturesMessage(List<uint> features)
    {
      this.features = features;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.features.Count);
      for (int index = 0; index < this.features.Count; ++index)
      {
        if (this.features[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.features[index] + ") on element 1 (starting at 1) of features.");
        writer.WriteByte((byte) this.features[index]);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        uint num2 = (uint) reader.ReadByte();
        if (num2 < 0U)
          throw new Exception("Forbidden value (" + (object) num2 + ") on elements of features.");
        this.features.Add(num2);
      }
    }
  }
}
