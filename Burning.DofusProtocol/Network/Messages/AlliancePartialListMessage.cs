using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AlliancePartialListMessage : AllianceListMessage
  {
    public new const uint Id = 6427;

    public override uint MessageId
    {
      get
      {
        return 6427;
      }
    }

    public AlliancePartialListMessage()
    {
    }

    public AlliancePartialListMessage(List<AllianceFactSheetInformations> alliances)
      : base(alliances)
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
