using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayGroupMonsterInformations : GameRolePlayActorInformations
  {
    public new const uint Id = 160;
    public GroupMonsterStaticInformations staticInfos;
    public int lootShare;
    public int alignmentSide;
    public bool keyRingBonus;
    public bool hasHardcoreDrop;
    public bool hasAVARewardToken;

    public override uint TypeId
    {
      get
      {
        return 160;
      }
    }

    public GameRolePlayGroupMonsterInformations()
    {
    }

    public GameRolePlayGroupMonsterInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      GroupMonsterStaticInformations staticInfos,
      int lootShare,
      int alignmentSide,
      bool keyRingBonus,
      bool hasHardcoreDrop,
      bool hasAVARewardToken)
      : base(contextualId, disposition, look)
    {
      this.staticInfos = staticInfos;
      this.lootShare = lootShare;
      this.alignmentSide = alignmentSide;
      this.keyRingBonus = keyRingBonus;
      this.hasHardcoreDrop = hasHardcoreDrop;
      this.hasAVARewardToken = hasAVARewardToken;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      int num = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.keyRingBonus), (byte) 1, this.hasHardcoreDrop), (byte) 2, this.hasAVARewardToken);
      writer.WriteByte((byte) num);
      writer.WriteShort((short) this.staticInfos.TypeId);
      this.staticInfos.Serialize(writer);
      if (this.lootShare < -1 || this.lootShare > 8)
        throw new Exception("Forbidden value (" + (object) this.lootShare + ") on element lootShare.");
      writer.WriteByte((byte) 0);
      writer.WriteByte((byte) 0);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadByte();
      this.keyRingBonus = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 0);
      this.hasHardcoreDrop = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 1);
      this.hasAVARewardToken = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num, (byte) 2);
      this.staticInfos = ProtocolTypeManager.GetInstance<GroupMonsterStaticInformations>((uint) reader.ReadUShort());
      this.staticInfos.Deserialize(reader);
      this.lootShare = (int) reader.ReadByte();
      if (this.lootShare >= -1)
      {
        int lootShare = this.lootShare;
      }
      Console.WriteLine(this.staticInfos.GetType().Name);
      this.alignmentSide = (int) reader.ReadByte();
    }
  }
}
