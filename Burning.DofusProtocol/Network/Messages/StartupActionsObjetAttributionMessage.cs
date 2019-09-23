using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StartupActionsObjetAttributionMessage : NetworkMessage
  {
    public const uint Id = 1303;
    public uint actionId;
    public double characterId;

    public override uint MessageId
    {
      get
      {
        return 1303;
      }
    }

    public StartupActionsObjetAttributionMessage()
    {
    }

    public StartupActionsObjetAttributionMessage(uint actionId, double characterId)
    {
      this.actionId = actionId;
      this.characterId = characterId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteInt((int) this.actionId);
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element characterId.");
      writer.WriteVarLong((long) this.characterId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.actionId = (uint) reader.ReadInt();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of StartupActionsObjetAttributionMessage.actionId.");
      this.characterId = (double) reader.ReadVarUhLong();
      if (this.characterId < 0.0 || this.characterId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.characterId + ") on element of StartupActionsObjetAttributionMessage.characterId.");
    }
  }
}
