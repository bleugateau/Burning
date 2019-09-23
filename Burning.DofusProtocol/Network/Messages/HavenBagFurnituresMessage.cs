using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class HavenBagFurnituresMessage : NetworkMessage
  {
    public List<HavenBagFurnitureInformation> furnituresInfos = new List<HavenBagFurnitureInformation>();
    public const uint Id = 6634;

    public override uint MessageId
    {
      get
      {
        return 6634;
      }
    }

    public HavenBagFurnituresMessage()
    {
    }

    public HavenBagFurnituresMessage(List<HavenBagFurnitureInformation> furnituresInfos)
    {
      this.furnituresInfos = furnituresInfos;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.furnituresInfos.Count);
      for (int index = 0; index < this.furnituresInfos.Count; ++index)
        this.furnituresInfos[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        HavenBagFurnitureInformation furnitureInformation = new HavenBagFurnitureInformation();
        furnitureInformation.Deserialize(reader);
        this.furnituresInfos.Add(furnitureInformation);
      }
    }
  }
}
