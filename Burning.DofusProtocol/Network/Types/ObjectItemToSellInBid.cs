using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemToSellInBid : ObjectItemToSell
  {
    public new const uint Id = 164;
    public uint unsoldDelay;

    public override uint TypeId
    {
      get
      {
        return 164;
      }
    }

    public ObjectItemToSellInBid()
    {
    }

    public ObjectItemToSellInBid(
      uint objectGID,
      List<ObjectEffect> effects,
      uint objectUID,
      uint quantity,
      double objectPrice,
      uint unsoldDelay)
      : base(objectGID, effects, objectUID, quantity, objectPrice)
    {
      this.unsoldDelay = unsoldDelay;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.unsoldDelay < 0U)
        throw new Exception("Forbidden value (" + (object) this.unsoldDelay + ") on element unsoldDelay.");
      writer.WriteInt((int) this.unsoldDelay);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.unsoldDelay = (uint) reader.ReadInt();
      if (this.unsoldDelay < 0U)
        throw new Exception("Forbidden value (" + (object) this.unsoldDelay + ") on element of ObjectItemToSellInBid.unsoldDelay.");
    }
  }
}
