using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockInstancesInformations : PaddockInformations
  {
    public List<PaddockBuyableInformations> paddocks = new List<PaddockBuyableInformations>();
    public new const uint Id = 509;

    public override uint TypeId
    {
      get
      {
        return 509;
      }
    }

    public PaddockInstancesInformations()
    {
    }

    public PaddockInstancesInformations(
      uint maxOutdoorMount,
      uint maxItems,
      List<PaddockBuyableInformations> paddocks)
      : base(maxOutdoorMount, maxItems)
    {
      this.paddocks = paddocks;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.paddocks.Count);
      for (int index = 0; index < this.paddocks.Count; ++index)
      {
        writer.WriteShort((short) this.paddocks[index].TypeId);
        this.paddocks[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PaddockBuyableInformations instance = ProtocolTypeManager.GetInstance<PaddockBuyableInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.paddocks.Add(instance);
      }
    }
  }
}
