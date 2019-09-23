using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayTreasureHintInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 471;
    public uint npcId;

    public override uint TypeId
    {
      get
      {
        return 471;
      }
    }

    public GameRolePlayTreasureHintInformations()
    {
    }

    public GameRolePlayTreasureHintInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      uint npcId)
      : base(contextualId, disposition, look)
    {
      this.npcId = npcId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element npcId.");
      writer.WriteVarShort((short) this.npcId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.npcId = (uint) reader.ReadVarUhShort();
      if (this.npcId < 0U)
        throw new Exception("Forbidden value (" + (object) this.npcId + ") on element of GameRolePlayTreasureHintInformations.npcId.");
    }
  }
}
