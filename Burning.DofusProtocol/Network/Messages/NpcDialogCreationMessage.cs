using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NpcDialogCreationMessage : NetworkMessage
  {
    public const uint Id = 5618;
    public double mapId;
    public int npcId;

    public override uint MessageId
    {
      get
      {
        return 5618;
      }
    }

    public NpcDialogCreationMessage()
    {
    }

    public NpcDialogCreationMessage(double mapId, int npcId)
    {
      this.mapId = mapId;
      this.npcId = npcId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      writer.WriteInt(this.npcId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of NpcDialogCreationMessage.mapId.");
      this.npcId = reader.ReadInt();
    }
  }
}
