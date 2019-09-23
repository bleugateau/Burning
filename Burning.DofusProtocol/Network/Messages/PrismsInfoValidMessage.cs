using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismsInfoValidMessage : NetworkMessage
  {
    public List<PrismFightersInformation> fights = new List<PrismFightersInformation>();
    public const uint Id = 6451;

    public override uint MessageId
    {
      get
      {
        return 6451;
      }
    }

    public PrismsInfoValidMessage()
    {
    }

    public PrismsInfoValidMessage(List<PrismFightersInformation> fights)
    {
      this.fights = fights;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.fights.Count);
      for (int index = 0; index < this.fights.Count; ++index)
        this.fights[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PrismFightersInformation fightersInformation = new PrismFightersInformation();
        fightersInformation.Deserialize(reader);
        this.fights.Add(fightersInformation);
      }
    }
  }
}
