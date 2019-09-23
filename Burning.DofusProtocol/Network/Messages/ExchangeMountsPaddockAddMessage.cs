using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMountsPaddockAddMessage : NetworkMessage
  {
    public List<MountClientData> mountDescription = new List<MountClientData>();
    public const uint Id = 6561;

    public override uint MessageId
    {
      get
      {
        return 6561;
      }
    }

    public ExchangeMountsPaddockAddMessage()
    {
    }

    public ExchangeMountsPaddockAddMessage(List<MountClientData> mountDescription)
    {
      this.mountDescription = mountDescription;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.mountDescription.Count);
      for (int index = 0; index < this.mountDescription.Count; ++index)
        this.mountDescription[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        MountClientData mountClientData = new MountClientData();
        mountClientData.Deserialize(reader);
        this.mountDescription.Add(mountClientData);
      }
    }
  }
}
