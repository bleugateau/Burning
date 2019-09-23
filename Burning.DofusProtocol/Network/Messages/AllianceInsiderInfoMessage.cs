using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceInsiderInfoMessage : NetworkMessage
  {
    public List<GuildInsiderFactSheetInformations> guilds = new List<GuildInsiderFactSheetInformations>();
    public List<PrismSubareaEmptyInfo> prisms = new List<PrismSubareaEmptyInfo>();
    public const uint Id = 6403;
    public AllianceFactSheetInformations allianceInfos;

    public override uint MessageId
    {
      get
      {
        return 6403;
      }
    }

    public AllianceInsiderInfoMessage()
    {
    }

    public AllianceInsiderInfoMessage(
      AllianceFactSheetInformations allianceInfos,
      List<GuildInsiderFactSheetInformations> guilds,
      List<PrismSubareaEmptyInfo> prisms)
    {
      this.allianceInfos = allianceInfos;
      this.guilds = guilds;
      this.prisms = prisms;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.allianceInfos.Serialize(writer);
      writer.WriteShort((short) this.guilds.Count);
      for (int index = 0; index < this.guilds.Count; ++index)
        this.guilds[index].Serialize(writer);
      writer.WriteShort((short) this.prisms.Count);
      for (int index = 0; index < this.prisms.Count; ++index)
      {
        writer.WriteShort((short) this.prisms[index].TypeId);
        this.prisms[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.allianceInfos = new AllianceFactSheetInformations();
      this.allianceInfos.Deserialize(reader);
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        GuildInsiderFactSheetInformations sheetInformations = new GuildInsiderFactSheetInformations();
        sheetInformations.Deserialize(reader);
        this.guilds.Add(sheetInformations);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        PrismSubareaEmptyInfo instance = ProtocolTypeManager.GetInstance<PrismSubareaEmptyInfo>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.prisms.Add(instance);
      }
    }
  }
}
