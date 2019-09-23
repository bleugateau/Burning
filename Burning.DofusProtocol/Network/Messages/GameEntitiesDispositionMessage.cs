using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameEntitiesDispositionMessage : NetworkMessage
  {
    public List<IdentifiedEntityDispositionInformations> dispositions = new List<IdentifiedEntityDispositionInformations>();
    public const uint Id = 5696;

    public override uint MessageId
    {
      get
      {
        return 5696;
      }
    }

    public GameEntitiesDispositionMessage()
    {
    }

    public GameEntitiesDispositionMessage(
      List<IdentifiedEntityDispositionInformations> dispositions)
    {
      this.dispositions = dispositions;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.dispositions.Count);
      for (int index = 0; index < this.dispositions.Count; ++index)
        this.dispositions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        IdentifiedEntityDispositionInformations dispositionInformations = new IdentifiedEntityDispositionInformations();
        dispositionInformations.Deserialize(reader);
        this.dispositions.Add(dispositionInformations);
      }
    }
  }
}
