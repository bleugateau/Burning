using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
  {
    public new const uint Id = 180;
    public string ownerName;
    public uint level;

    public override uint TypeId
    {
      get
      {
        return 180;
      }
    }

    public GameRolePlayMountInformations()
    {
    }

    public GameRolePlayMountInformations(
      double contextualId,
      EntityDispositionInformations disposition,
      EntityLook look,
      string name,
      string ownerName,
      uint level)
      : base(contextualId, disposition, look, name)
    {
      this.ownerName = ownerName;
      this.level = level;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteUTF(this.ownerName);
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element level.");
      writer.WriteByte((byte) this.level);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.ownerName = reader.ReadUTF();
      this.level = (uint) reader.ReadByte();
      if (this.level < 0U || this.level > (uint) byte.MaxValue)
        throw new Exception("Forbidden value (" + (object) this.level + ") on element of GameRolePlayMountInformations.level.");
    }
  }
}
