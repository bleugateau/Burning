using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations
  {
    public new const uint Id = 3;
    public uint monsterId;
    public int powerLevel;

    public override uint TypeId
    {
      get
      {
        return 3;
      }
    }

    public GameRolePlayMutantInformations()
    {
    }

    public GameRolePlayMutantInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name,
      HumanInformations humanoidInfo,
      uint accountId,
      uint monsterId,
      int powerLevel)
      : base(contextualId, disposition, look, name, humanoidInfo, accountId)
    {
      this.monsterId = monsterId;
      this.powerLevel = powerLevel;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.monsterId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterId + ") on element monsterId.");
      writer.WriteVarShort((short) this.monsterId);
      writer.WriteByte((byte) this.powerLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.monsterId = (uint) reader.ReadVarUhShort();
      if (this.monsterId < 0U)
        throw new Exception("Forbidden value (" + (object) this.monsterId + ") on element of GameRolePlayMutantInformations.monsterId.");
      this.powerLevel = (int) reader.ReadByte();
    }
  }
}
