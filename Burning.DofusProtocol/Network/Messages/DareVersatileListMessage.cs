using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareVersatileListMessage : NetworkMessage
  {
    public List<DareVersatileInformations> dares = new List<DareVersatileInformations>();
    public const uint Id = 6657;

    public override uint MessageId
    {
      get
      {
        return 6657;
      }
    }

    public DareVersatileListMessage()
    {
    }

    public DareVersatileListMessage(List<DareVersatileInformations> dares)
    {
      this.dares = dares;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.dares.Count);
      for (int index = 0; index < this.dares.Count; ++index)
        this.dares[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        DareVersatileInformations versatileInformations = new DareVersatileInformations();
        versatileInformations.Deserialize(reader);
        this.dares.Add(versatileInformations);
      }
    }
  }
}
