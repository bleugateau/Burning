using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PaddockInformations
  {
    public const uint Id = 132;
    public uint maxOutdoorMount;
    public uint maxItems;

    public virtual uint TypeId
    {
      get
      {
        return 132;
      }
    }

    public PaddockInformations()
    {
    }

    public PaddockInformations(uint maxOutdoorMount, uint maxItems)
    {
      this.maxOutdoorMount = maxOutdoorMount;
      this.maxItems = maxItems;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.maxOutdoorMount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxOutdoorMount + ") on element maxOutdoorMount.");
      writer.WriteVarShort((short) this.maxOutdoorMount);
      if (this.maxItems < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxItems + ") on element maxItems.");
      writer.WriteVarShort((short) this.maxItems);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.maxOutdoorMount = (uint) reader.ReadVarUhShort();
      if (this.maxOutdoorMount < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxOutdoorMount + ") on element of PaddockInformations.maxOutdoorMount.");
      this.maxItems = (uint) reader.ReadVarUhShort();
      if (this.maxItems < 0U)
        throw new Exception("Forbidden value (" + (object) this.maxItems + ") on element of PaddockInformations.maxItems.");
    }
  }
}
