using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceFactsMessage : NetworkMessage
  {
    public List<GuildInAllianceInformations> guilds = new List<GuildInAllianceInformations>();
    public List<uint> controlledSubareaIds = new List<uint>();
    public const uint Id = 6414;
    public AllianceFactSheetInformations infos;
    public double leaderCharacterId;
    public string leaderCharacterName;

    public override uint MessageId
    {
      get
      {
        return 6414;
      }
    }

    public AllianceFactsMessage()
    {
    }

    public AllianceFactsMessage(
      AllianceFactSheetInformations infos,
      List<GuildInAllianceInformations> guilds,
      List<uint> controlledSubareaIds,
      double leaderCharacterId,
      string leaderCharacterName)
    {
      this.infos = infos;
      this.guilds = guilds;
      this.controlledSubareaIds = controlledSubareaIds;
      this.leaderCharacterId = leaderCharacterId;
      this.leaderCharacterName = leaderCharacterName;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.infos.TypeId);
      this.infos.Serialize(writer);
      writer.WriteShort((short) this.guilds.Count);
      for (int index = 0; index < this.guilds.Count; ++index)
        this.guilds[index].Serialize(writer);
      writer.WriteShort((short) this.controlledSubareaIds.Count);
      for (int index = 0; index < this.controlledSubareaIds.Count; ++index)
      {
        if (this.controlledSubareaIds[index] < 0U)
          throw new Exception("Forbidden value (" + (object) this.controlledSubareaIds[index] + ") on element 3 (starting at 1) of controlledSubareaIds.");
        writer.WriteVarShort((short) this.controlledSubareaIds[index]);
      }
      if (this.leaderCharacterId < 0.0 || this.leaderCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderCharacterId + ") on element leaderCharacterId.");
      writer.WriteVarLong((long) this.leaderCharacterId);
      writer.WriteUTF(this.leaderCharacterName);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.infos = ProtocolTypeManager.GetInstance<AllianceFactSheetInformations>((uint) reader.ReadUShort());
      this.infos.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        GuildInAllianceInformations allianceInformations = new GuildInAllianceInformations();
        allianceInformations.Deserialize(reader);
        this.guilds.Add(allianceInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        uint num3 = (uint) reader.ReadVarUhShort();
        if (num3 < 0U)
          throw new Exception("Forbidden value (" + (object) num3 + ") on elements of controlledSubareaIds.");
        this.controlledSubareaIds.Add(num3);
      }
      this.leaderCharacterId = (double) reader.ReadVarUhLong();
      if (this.leaderCharacterId < 0.0 || this.leaderCharacterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.leaderCharacterId + ") on element of AllianceFactsMessage.leaderCharacterId.");
      this.leaderCharacterName = reader.ReadUTF();
    }
  }
}
