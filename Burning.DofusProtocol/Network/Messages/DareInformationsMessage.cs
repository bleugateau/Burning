using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;

namespace Burning.DofusProtocol.Network.Messages
{
  public class DareInformationsMessage : NetworkMessage
  {
    public const uint Id = 6656;
    public DareInformations dareFixedInfos;
    public DareVersatileInformations dareVersatilesInfos;

    public override uint MessageId
    {
      get
      {
        return 6656;
      }
    }

    public DareInformationsMessage()
    {
    }

    public DareInformationsMessage(
      DareInformations dareFixedInfos,
      DareVersatileInformations dareVersatilesInfos)
    {
      this.dareFixedInfos = dareFixedInfos;
      this.dareVersatilesInfos = dareVersatilesInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.dareFixedInfos.Serialize(writer);
      this.dareVersatilesInfos.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.dareFixedInfos = new DareInformations();
      this.dareFixedInfos.Deserialize(reader);
      this.dareVersatilesInfos = new DareVersatileInformations();
      this.dareVersatilesInfos.Deserialize(reader);
    }
  }
}
