using FlatyBot.Common.IO;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayMerchantInformations : GameRolePlayNamedActorInformations
  {
    public List<HumanOption> options = new List<HumanOption>();
    public new const uint Id = 129;
    public uint sellType;

    public override uint TypeId
    {
      get
      {
        return 129;
      }
    }

    public GameRolePlayMerchantInformations()
    {
    }

    public GameRolePlayMerchantInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name,
      uint sellType,
      List<HumanOption> options)
      : base(contextualId, disposition, look, name)
    {
      this.sellType = sellType;
      this.options = options;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.sellType < 0U)
        throw new Exception("Forbidden value (" + (object) this.sellType + ") on element sellType.");
      writer.WriteByte((byte) this.sellType);
      writer.WriteShort((short) this.options.Count);
      for (int index = 0; index < this.options.Count; ++index)
      {
        writer.WriteShort((short) this.options[index].TypeId);
        this.options[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.sellType = (uint) reader.ReadByte();
      if (this.sellType < 0U)
        throw new Exception("Forbidden value (" + (object) this.sellType + ") on element of GameRolePlayMerchantInformations.sellType.");
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        HumanOption instance = ProtocolTypeManager.GetInstance<HumanOption>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.options.Add(instance);
      }
    }
  }
}
