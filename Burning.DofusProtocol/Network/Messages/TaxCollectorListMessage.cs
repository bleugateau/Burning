using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class TaxCollectorListMessage : AbstractTaxCollectorListMessage
  {
    public List<TaxCollectorFightersInformation> fightersInformations = new List<TaxCollectorFightersInformation>();
    public new const uint Id = 5930;
    public uint nbcollectorMax;
    public uint infoType;

    public override uint MessageId
    {
      get
      {
        return 5930;
      }
    }

    public TaxCollectorListMessage()
    {
    }

    public TaxCollectorListMessage(
      List<TaxCollectorInformations> informations,
      uint nbcollectorMax,
      List<TaxCollectorFightersInformation> fightersInformations,
      uint infoType)
      : base(informations)
    {
      this.nbcollectorMax = nbcollectorMax;
      this.fightersInformations = fightersInformations;
      this.infoType = infoType;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.nbcollectorMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbcollectorMax + ") on element nbcollectorMax.");
      writer.WriteByte((byte) this.nbcollectorMax);
      writer.WriteShort((short) this.fightersInformations.Count);
      for (int index = 0; index < this.fightersInformations.Count; ++index)
        this.fightersInformations[index].Serialize(writer);
      writer.WriteByte((byte) this.infoType);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.nbcollectorMax = (uint) reader.ReadByte();
      if (this.nbcollectorMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbcollectorMax + ") on element of TaxCollectorListMessage.nbcollectorMax.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        TaxCollectorFightersInformation fightersInformation = new TaxCollectorFightersInformation();
        fightersInformation.Deserialize(reader);
        this.fightersInformations.Add(fightersInformation);
      }
      this.infoType = (uint) reader.ReadByte();
      if (this.infoType < 0U)
        throw new Exception("Forbidden value (" + (object) this.infoType + ") on element of TaxCollectorListMessage.infoType.");
    }
  }
}
