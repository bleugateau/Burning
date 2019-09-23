using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayHumanoidInformations : GameRolePlayNamedActorInformations
  {
    public new const uint Id = 159;
    public HumanInformations humanoidInfo;
    public uint accountId;

    public override uint TypeId
    {
      get
      {
        return 159;
      }
    }

    public GameRolePlayHumanoidInformations()
    {
    }

    public GameRolePlayHumanoidInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name,
      HumanInformations humanoidInfo,
      uint accountId)
      : base(contextualId, disposition, look, name)
    {
      this.humanoidInfo = humanoidInfo;
      this.accountId = accountId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.humanoidInfo.TypeId);
      this.humanoidInfo.Serialize(writer);
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.humanoidInfo = ProtocolTypeManager.GetInstance<HumanInformations>((uint) reader.ReadUShort());
      this.humanoidInfo.Deserialize(reader);
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of GameRolePlayHumanoidInformations.accountId.");
    }
  }
}
