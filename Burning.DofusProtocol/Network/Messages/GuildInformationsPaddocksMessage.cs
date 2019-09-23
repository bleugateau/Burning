using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildInformationsPaddocksMessage : NetworkMessage
  {
    public List<PaddockContentInformations> paddocksInformations = new List<PaddockContentInformations>();
    public const uint Id = 5959;
    public uint nbPaddockMax;

    public override uint MessageId
    {
      get
      {
        return 5959;
      }
    }

    public GuildInformationsPaddocksMessage()
    {
    }

    public GuildInformationsPaddocksMessage(
      uint nbPaddockMax,
      List<PaddockContentInformations> paddocksInformations)
    {
      this.nbPaddockMax = nbPaddockMax;
      this.paddocksInformations = paddocksInformations;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.nbPaddockMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbPaddockMax + ") on element nbPaddockMax.");
      writer.WriteByte((byte) this.nbPaddockMax);
      writer.WriteShort((short) this.paddocksInformations.Count);
      for (int index = 0; index < this.paddocksInformations.Count; ++index)
        this.paddocksInformations[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.nbPaddockMax = (uint) reader.ReadByte();
      if (this.nbPaddockMax < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbPaddockMax + ") on element of GuildInformationsPaddocksMessage.nbPaddockMax.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        PaddockContentInformations contentInformations = new PaddockContentInformations();
        contentInformations.Deserialize(reader);
        this.paddocksInformations.Add(contentInformations);
      }
    }
  }
}
