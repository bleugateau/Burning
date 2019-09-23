using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GuildFactsMessage : NetworkMessage
  {
    public List<CharacterMinimalGuildPublicInformations> members = new List<CharacterMinimalGuildPublicInformations>();
    public const uint Id = 6415;
    public GuildFactSheetInformations infos;
    public uint creationDate;
    public uint nbTaxCollectors;

    public override uint MessageId
    {
      get
      {
        return 6415;
      }
    }

    public GuildFactsMessage()
    {
    }

    public GuildFactsMessage(
      GuildFactSheetInformations infos,
      uint creationDate,
      uint nbTaxCollectors,
      List<CharacterMinimalGuildPublicInformations> members)
    {
      this.infos = infos;
      this.creationDate = creationDate;
      this.nbTaxCollectors = nbTaxCollectors;
      this.members = members;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.infos.TypeId);
      this.infos.Serialize(writer);
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element creationDate.");
      writer.WriteInt((int) this.creationDate);
      if (this.nbTaxCollectors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTaxCollectors + ") on element nbTaxCollectors.");
      writer.WriteVarShort((short) this.nbTaxCollectors);
      writer.WriteShort((short) this.members.Count);
      for (int index = 0; index < this.members.Count; ++index)
        this.members[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.infos = ProtocolTypeManager.GetInstance<GuildFactSheetInformations>((uint) reader.ReadUShort());
      this.infos.Deserialize(reader);
      this.creationDate = (uint) reader.ReadInt();
      if (this.creationDate < 0U)
        throw new Exception("Forbidden value (" + (object) this.creationDate + ") on element of GuildFactsMessage.creationDate.");
      this.nbTaxCollectors = (uint) reader.ReadVarUhShort();
      if (this.nbTaxCollectors < 0U)
        throw new Exception("Forbidden value (" + (object) this.nbTaxCollectors + ") on element of GuildFactsMessage.nbTaxCollectors.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        CharacterMinimalGuildPublicInformations publicInformations = new CharacterMinimalGuildPublicInformations();
        publicInformations.Deserialize(reader);
        this.members.Add(publicInformations);
      }
    }
  }
}
