using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AllianceListMessage : NetworkMessage
  {
    public List<AllianceFactSheetInformations> alliances = new List<AllianceFactSheetInformations>();
    public const uint Id = 6408;

    public override uint MessageId
    {
      get
      {
        return 6408;
      }
    }

    public AllianceListMessage()
    {
    }

    public AllianceListMessage(List<AllianceFactSheetInformations> alliances)
    {
      this.alliances = alliances;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.alliances.Count);
      for (int index = 0; index < this.alliances.Count; ++index)
        this.alliances[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AllianceFactSheetInformations sheetInformations = new AllianceFactSheetInformations();
        sheetInformations.Deserialize(reader);
        this.alliances.Add(sheetInformations);
      }
    }
  }
}
