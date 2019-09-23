using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameActionFightCastOnTargetRequestMessage : NetworkMessage
  {
    public const uint Id = 6330;
    public uint spellId;
    public double targetId;

    public override uint MessageId
    {
      get
      {
        return 6330;
      }
    }

    public GameActionFightCastOnTargetRequestMessage()
    {
    }

    public GameActionFightCastOnTargetRequestMessage(uint spellId, double targetId)
    {
      this.spellId = spellId;
      this.targetId = targetId;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element spellId.");
      writer.WriteVarShort((short) this.spellId);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.spellId = (uint) reader.ReadVarUhShort();
      if (this.spellId < 0U)
        throw new Exception("Forbidden value (" + (object) this.spellId + ") on element of GameActionFightCastOnTargetRequestMessage.spellId.");
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of GameActionFightCastOnTargetRequestMessage.targetId.");
    }
  }
}
