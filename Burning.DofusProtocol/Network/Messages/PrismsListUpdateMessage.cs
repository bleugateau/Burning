using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PrismsListUpdateMessage : PrismsListMessage
  {
    public new const uint Id = 6438;

    public override uint MessageId
    {
      get
      {
        return 6438;
      }
    }

    public PrismsListUpdateMessage()
    {
    }

    public PrismsListUpdateMessage(List<PrismSubareaEmptyInfo> prisms)
      : base(prisms)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
