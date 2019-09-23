using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismsListMessage : NetworkMessage
  {
    public List<PrismSubareaEmptyInfo> prisms = new List<PrismSubareaEmptyInfo>();
    public const uint Id = 6440;

    public override uint MessageId
    {
      get
      {
        return 6440;
      }
    }

    public PrismsListMessage()
    {
    }

    public PrismsListMessage(List<PrismSubareaEmptyInfo> prisms)
    {
      this.prisms = prisms;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.prisms.Count);
      for (int index = 0; index < this.prisms.Count; ++index)
      {
        writer.WriteShort((short) this.prisms[index].TypeId);
        this.prisms[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PrismSubareaEmptyInfo instance = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.prisms.Add(instance);
      }
    }
  }
}
