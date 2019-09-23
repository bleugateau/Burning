using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareSubscribedListMessage : NetworkMessage
  {
    public List<DareInformations> daresFixedInfos = new List<DareInformations>();
    public List<DareVersatileInformations> daresVersatilesInfos = new List<DareVersatileInformations>();
    public const uint Id = 6658;

    public override uint MessageId
    {
      get
      {
        return 6658;
      }
    }

    public DareSubscribedListMessage()
    {
    }

    public DareSubscribedListMessage(
      List<DareInformations> daresFixedInfos,
      List<DareVersatileInformations> daresVersatilesInfos)
    {
      this.daresFixedInfos = daresFixedInfos;
      this.daresVersatilesInfos = daresVersatilesInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.daresFixedInfos.Count);
      for (int index = 0; index < this.daresFixedInfos.Count; ++index)
        this.daresFixedInfos[index].Serialize(writer);
      writer.WriteShort((short) this.daresVersatilesInfos.Count);
      for (int index = 0; index < this.daresVersatilesInfos.Count; ++index)
        this.daresVersatilesInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        DareInformations dareInformations = new DareInformations();
        dareInformations.Deserialize(reader);
        this.daresFixedInfos.Add(dareInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        DareVersatileInformations versatileInformations = new DareVersatileInformations();
        versatileInformations.Deserialize(reader);
        this.daresVersatilesInfos.Add(versatileInformations);
      }
    }
  }
}
