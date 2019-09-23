using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class IdolFightPreparationUpdateMessage : NetworkMessage
  {
    public List<Idol> idols = new List<Idol>();
    public const uint Id = 6586;
    public uint idolSource;

    public override uint MessageId
    {
      get
      {
        return 6586;
      }
    }

    public IdolFightPreparationUpdateMessage()
    {
    }

    public IdolFightPreparationUpdateMessage(uint idolSource, List<Idol> idols)
    {
      this.idolSource = idolSource;
      this.idols = idols;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.idolSource);
      writer.WriteShort((short) this.idols.Count);
      for (int index = 0; index < this.idols.Count; ++index)
      {
        writer.WriteShort((short) this.idols[index].TypeId);
        this.idols[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.idolSource = (uint) reader.ReadByte();
      if (this.idolSource < 0U)
        throw new Exception("Forbidden value (" + (object) this.idolSource + ") on element of IdolFightPreparationUpdateMessage.idolSource.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        Idol instance = ProtocolTypeManager.GetInstance<Idol>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.idols.Add(instance);
      }
    }
  }
}
