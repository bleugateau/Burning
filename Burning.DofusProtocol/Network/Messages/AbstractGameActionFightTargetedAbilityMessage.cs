using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
  {
    public new const uint Id = 6118;
    public double targetId;
    public int destinationCellId;
    public uint critical;
    public bool silentCast;
    public bool verboseCast;

    public override uint MessageId
    {
      get
      {
        return 6118;
      }
    }

    public AbstractGameActionFightTargetedAbilityMessage()
    {
    }

    public AbstractGameActionFightTargetedAbilityMessage(
      uint actionId,
      double sourceId,
      double targetId,
      int destinationCellId,
      uint critical,
      bool silentCast,
      bool verboseCast)
      : base(actionId, sourceId)
    {
      this.targetId = targetId;
      this.destinationCellId = destinationCellId;
      this.critical = critical;
      this.silentCast = silentCast;
      this.verboseCast = verboseCast;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.silentCast), (byte) 1, this.verboseCast);
      writer.WriteByte((byte) num);
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element targetId.");
      writer.WriteDouble(this.targetId);
      if (this.destinationCellId < -1 || this.destinationCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.destinationCellId + ") on element destinationCellId.");
      writer.WriteShort((short) this.destinationCellId);
      writer.WriteByte((byte) this.critical);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.silentCast = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.verboseCast = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.targetId = reader.ReadDouble();
      if (this.targetId < -9.00719925474099E+15 || this.targetId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.targetId + ") on element of AbstractGameActionFightTargetedAbilityMessage.targetId.");
      this.destinationCellId = (int) reader.ReadShort();
      if (this.destinationCellId < -1 || this.destinationCellId > 559)
        throw new Exception("Forbidden value (" + (object) this.destinationCellId + ") on element of AbstractGameActionFightTargetedAbilityMessage.destinationCellId.");
      this.critical = (uint) reader.ReadByte();
      if (this.critical < 0U)
        throw new Exception("Forbidden value (" + (object) this.critical + ") on element of AbstractGameActionFightTargetedAbilityMessage.critical.");
    }
  }
}
