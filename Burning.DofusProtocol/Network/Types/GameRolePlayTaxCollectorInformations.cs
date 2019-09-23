using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 148;
    public TaxCollectorStaticInformations identification;
    public uint guildLevel;
    public int taxCollectorAttack;

    public override uint TypeId
    {
      get
      {
        return 148;
      }
    }

    public GameRolePlayTaxCollectorInformations()
    {
    }

    public GameRolePlayTaxCollectorInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      TaxCollectorStaticInformations identification,
      uint guildLevel,
      int taxCollectorAttack)
      : base(contextualId, disposition, look)
    {
      this.identification = identification;
      this.guildLevel = guildLevel;
      this.taxCollectorAttack = taxCollectorAttack;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.identification.TypeId);
      this.identification.Serialize(writer);
      if (this.guildLevel < 0U || this.guildLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element guildLevel.");
      writer.WriteByte((byte) this.guildLevel);
      writer.WriteInt(this.taxCollectorAttack);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.identification = ProtocolTypeManager.GetInstance<TaxCollectorStaticInformations>((uint) reader.ReadUShort());
      this.identification.Deserialize(reader);
      this.guildLevel = (uint) reader.ReadByte();
      if (this.guildLevel < 0U || this.guildLevel > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.guildLevel + ") on element of GameRolePlayTaxCollectorInformations.guildLevel.");
      this.taxCollectorAttack = reader.ReadInt();
    }
  }
}
