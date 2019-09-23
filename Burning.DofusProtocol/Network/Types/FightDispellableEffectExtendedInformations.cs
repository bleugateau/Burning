using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class FightDispellableEffectExtendedInformations
  {
    public const uint Id = 208;
    public uint actionId;
    public double sourceId;
    public AbstractFightDispellableEffect effect;

    public virtual uint TypeId
    {
      get
      {
        return 208;
      }
    }

    public FightDispellableEffectExtendedInformations()
    {
    }

    public FightDispellableEffectExtendedInformations(
      uint actionId,
      double sourceId,
      AbstractFightDispellableEffect effect)
    {
      this.actionId = actionId;
      this.sourceId = sourceId;
      this.effect = effect;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element actionId.");
      writer.WriteVarShort((short) this.actionId);
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element sourceId.");
      writer.WriteDouble(this.sourceId);
      writer.WriteShort((short) this.effect.TypeId);
      this.effect.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.actionId = (uint) reader.ReadVarUhShort();
      if (this.actionId < 0U)
        throw new Exception("Forbidden value (" + (object) this.actionId + ") on element of FightDispellableEffectExtendedInformations.actionId.");
      this.sourceId = reader.ReadDouble();
      if (this.sourceId < -9.00719925474099E+15 || this.sourceId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.sourceId + ") on element of FightDispellableEffectExtendedInformations.sourceId.");
      this.effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>((uint) reader.ReadUShort());
      this.effect.Deserialize(reader);
    }
  }
}
