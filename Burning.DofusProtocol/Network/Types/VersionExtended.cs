using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class VersionExtended : Version
  {
    public new const uint Id = 393;
    public uint install;
    public uint technology;

    public override uint TypeId
    {
      get
      {
        return 393;
      }
    }

    public VersionExtended()
    {
    }

    public VersionExtended(
      uint major,
      uint minor,
      uint release,
      uint revision,
      uint patch,
      uint buildType,
      uint install,
      uint technology)
      : base(major, minor, release, revision, patch, buildType)
    {
      this.install = install;
      this.technology = technology;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.install);
      writer.WriteByte((byte) this.technology);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.install = (uint) reader.ReadByte();
      if (this.install < 0U)
        throw new Exception("Forbidden value (" + (object) this.install + ") on element of VersionExtended.install.");
      this.technology = (uint) reader.ReadByte();
      if (this.technology < 0U)
        throw new Exception("Forbidden value (" + (object) this.technology + ") on element of VersionExtended.technology.");
    }
  }
}
