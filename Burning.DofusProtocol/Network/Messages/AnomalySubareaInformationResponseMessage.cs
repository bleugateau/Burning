using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AnomalySubareaInformationResponseMessage : NetworkMessage
  {
    public List<AnomalySubareaInformation> subareas = new List<AnomalySubareaInformation>();
    public const uint Id = 6836;

    public override uint MessageId
    {
      get
      {
        return 6836;
      }
    }

    public AnomalySubareaInformationResponseMessage()
    {
    }

    public AnomalySubareaInformationResponseMessage(List<AnomalySubareaInformation> subareas)
    {
      this.subareas = subareas;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.subareas.Count);
      for (int index = 0; index < this.subareas.Count; ++index)
        this.subareas[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AnomalySubareaInformation subareaInformation = new AnomalySubareaInformation();
        subareaInformation.Deserialize(reader);
        this.subareas.Add(subareaInformation);
      }
    }
  }
}
