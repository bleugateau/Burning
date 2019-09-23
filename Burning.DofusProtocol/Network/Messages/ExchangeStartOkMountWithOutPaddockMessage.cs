using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
  {
    public List<MountClientData> stabledMountsDescription = new List<MountClientData>();
    public const uint Id = 5991;

    public override uint MessageId
    {
      get
      {
        return 5991;
      }
    }

    public ExchangeStartOkMountWithOutPaddockMessage()
    {
    }

    public ExchangeStartOkMountWithOutPaddockMessage(List<MountClientData> stabledMountsDescription)
    {
      this.stabledMountsDescription = stabledMountsDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.stabledMountsDescription.Count);
      for (int index = 0; index < this.stabledMountsDescription.Count; ++index)
        this.stabledMountsDescription[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MountClientData mountClientData = new MountClientData();
        mountClientData.Deserialize(reader);
        this.stabledMountsDescription.Add(mountClientData);
      }
    }
  }
}
