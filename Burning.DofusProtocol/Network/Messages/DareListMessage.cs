using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareListMessage : NetworkMessage
  {
    public List<DareInformations> dares = new List<DareInformations>();
    public const uint Id = 6661;

    public override uint MessageId
    {
      get
      {
        return 6661;
      }
    }

    public DareListMessage()
    {
    }

    public DareListMessage(List<DareInformations> dares)
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
        DareInformations dareInformations = new DareInformations();
        dareInformations.Deserialize(reader);
        this.dares.Add(dareInformations);
      }
    }
  }
}
