using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightCastRequestMessage : NetworkMessage
  {
    public const uint Id = 1005;
    public uint spellId;
    public int cellId;

    public override uint MessageId
    {
      get
      {
        return 1005;
      }
    }

    public GameActionFightCastRequestMessage()
    {
    }

    public GameActionFightCastRequestMessage(uint spellId, int cellId)
    {
      this.spellId = spellId;
      this.cellId = cellId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element cellId.");
      writer.WriteShort((short) this.cellId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameActionFightCastRequestMessage.spellId.");
      this.cellId = (int) reader.ReadShort();
      if (this.cellId < -1 || this.cellId > 559)
        throw new Exception("Forbidden value (" + (object) this.cellId + ") on element of GameActionFightCastRequestMessage.cellId.");
    }
  }
}
