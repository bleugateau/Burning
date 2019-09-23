using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameFightStartMessage : NetworkMessage
  {
    public List<Idol> idols = new List<Idol>();
    public const uint Id = 712;

    public override uint MessageId
    {
      get
      {
        return 712;
      }
    }

    public GameFightStartMessage()
    {
    }

    public GameFightStartMessage(List<Idol> idols)
    {
      this.idols = idols;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.idols.Count);
      for (int index = 0; index < this.idols.Count; ++index)
        this.idols[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        Idol idol = new Idol();
        idol.Deserialize(reader);
        this.idols.Add(idol);
      }
    }
  }
}
