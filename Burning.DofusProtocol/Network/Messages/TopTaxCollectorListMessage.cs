using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
  {
    public new const uint Id = 6565;
    public bool isDungeon;

    public override uint MessageId
    {
      get
      {
        return 6565;
      }
    }

    public TopTaxCollectorListMessage()
    {
    }

    public TopTaxCollectorListMessage(List<TaxCollectorInformations> informations, bool isDungeon)
      : base(informations)
    {
      this.isDungeon = isDungeon;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.isDungeon);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.isDungeon = reader.ReadBoolean();
    }
  }
}
