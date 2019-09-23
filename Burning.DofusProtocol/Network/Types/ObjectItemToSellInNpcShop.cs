using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class ObjectItemToSellInNpcShop : ObjectItemMinimalInformation
  {
    public new const uint Id = 352;
    public double objectPrice;
    public string buyCriterion;

    public override uint TypeId
    {
      get
      {
        return 352;
      }
    }

    public ObjectItemToSellInNpcShop()
    {
    }

    public ObjectItemToSellInNpcShop(
      uint objectGID,
      List<ObjectEffect> effects,
      double objectPrice,
      string buyCriterion)
      : base(objectGID, effects)
    {
      this.objectPrice = objectPrice;
      this.buyCriterion = buyCriterion;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element objectPrice.");
      writer.WriteVarLong((long) this.objectPrice);
      writer.WriteUTF(this.buyCriterion);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.objectPrice = (double) reader.ReadVarUhLong();
      if (this.objectPrice < 0.0 || this.objectPrice > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.objectPrice + ") on element of ObjectItemToSellInNpcShop.objectPrice.");
      this.buyCriterion = reader.ReadUTF();
    }
  }
}
