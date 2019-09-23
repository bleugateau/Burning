using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayNpcInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 156;
    public uint npcId;
    public bool sex;
    public uint specialArtworkId;

    public override uint TypeId
    {
      get
      {
        return 156;
      }
    }

    public GameRolePlayNpcInformations()
    {
    }

    public GameRolePlayNpcInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      uint npcId,
      bool sex,
      uint specialArtworkId)
      : base(contextualId, disposition, look)
    {
      this.npcId = npcId;
      this.sex = sex;
      this.specialArtworkId = specialArtworkId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element npcId.");
      writer.WriteVarShort((short) this.npcId);
      writer.WriteBoolean(this.sex);
      if (this.specialArtworkId < 0U)
        throw new Exception("Forbidden value (" + (object) this.specialArtworkId + ") on element specialArtworkId.");
      writer.WriteVarShort((short) this.specialArtworkId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.npcId = (uint) reader.ReadVarUhShort();
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element of GameRolePlayNpcInformations.npcId.");
      this.sex = reader.ReadBoolean();
      this.specialArtworkId = (uint) reader.ReadVarUhShort();
      if (this.specialArtworkId < 0U)
        throw new Exception("Forbidden value (" + (object) this.specialArtworkId + ") on element of GameRolePlayNpcInformations.specialArtworkId.");
    }
  }
}
