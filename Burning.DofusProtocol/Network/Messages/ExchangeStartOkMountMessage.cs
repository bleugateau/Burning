using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
  {
    public List<MountClientData> paddockedMountsDescription = new List<MountClientData>();
    public new const uint Id = 5979;

    public override uint MessageId
    {
      get
      {
        return 5979;
      }
    }

    public ExchangeStartOkMountMessage()
    {
    }

    public ExchangeStartOkMountMessage(
      List<MountClientData> stabledMountsDescription,
      List<MountClientData> paddockedMountsDescription)
      : base(stabledMountsDescription)
    {
      this.paddockedMountsDescription = paddockedMountsDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.paddockedMountsDescription.Count);
      for (int index = 0; index < this.paddockedMountsDescription.Count; ++index)
        this.paddockedMountsDescription[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MountClientData mountClientData = new MountClientData();
        mountClientData.Deserialize(reader);
        this.paddockedMountsDescription.Add(mountClientData);
      }
    }
  }
}
