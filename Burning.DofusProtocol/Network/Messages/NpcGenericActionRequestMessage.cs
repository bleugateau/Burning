using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class NpcGenericActionRequestMessage : NetworkMessage
  {
    public const uint Id = 5898;
    public int npcId;
    public uint npcActionId;
    public double npcMapId;

    public override uint MessageId
    {
      get
      {
        return 5898;
      }
    }

    public NpcGenericActionRequestMessage()
    {
    }

    public NpcGenericActionRequestMessage(int npcId, uint npcActionId, double npcMapId)
    {
      this.npcId = npcId;
      this.npcActionId = npcActionId;
      this.npcMapId = npcMapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteInt(this.npcId);
      if (this.npcActionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcActionId + ") on element npcActionId.");
      writer.WriteByte((byte) this.npcActionId);
      if (this.npcMapId < 0.0 || this.npcMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcMapId + ") on element npcMapId.");
      writer.WriteDouble(this.npcMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.npcId = reader.ReadInt();
      this.npcActionId = (uint) reader.ReadByte();
      if (this.npcActionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcActionId + ") on element of NpcGenericActionRequestMessage.npcActionId.");
      this.npcMapId = reader.ReadDouble();
      if (this.npcMapId < 0.0 || this.npcMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.npcMapId + ") on element of NpcGenericActionRequestMessage.npcMapId.");
    }
  }
}
