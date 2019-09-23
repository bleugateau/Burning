using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class Version
  {
    public const uint Id = 11;
    public uint major;
    public uint minor;
    public uint release;
    public uint revision;
    public uint patch;
    public uint buildType;

    public virtual uint TypeId
    {
      get
      {
        return 11;
      }
    }

    public Version()
    {
    }

    public Version(
      uint major,
      uint minor,
      uint release,
      uint revision,
      uint patch,
      uint buildType)
    {
      this.major = major;
      this.minor = minor;
      this.release = release;
      this.revision = revision;
      this.patch = patch;
      this.buildType = buildType;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.major < 0U)
        throw new Exception("Forbidden value (" + (object) this.major + ") on element major.");
      writer.WriteByte((byte) this.major);
      if (this.minor < 0U)
        throw new Exception("Forbidden value (" + (object) this.minor + ") on element minor.");
      writer.WriteByte((byte) this.minor);
      if (this.release < 0U)
        throw new Exception("Forbidden value (" + (object) this.release + ") on element release.");
      writer.WriteByte((byte) this.release);
      if (this.revision < 0U)
        throw new Exception("Forbidden value (" + (object) this.revision + ") on element revision.");
      writer.WriteInt((int) this.revision);
      if (this.patch < 0U)
        throw new Exception("Forbidden value (" + (object) this.patch + ") on element patch.");
      writer.WriteByte((byte) this.patch);
      writer.WriteByte((byte) this.buildType);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.major = (uint) reader.ReadByte();
      if (this.major < 0U)
        throw new Exception("Forbidden value (" + (object) this.major + ") on element of Version.major.");
      this.minor = (uint) reader.ReadByte();
      if (this.minor < 0U)
        throw new Exception("Forbidden value (" + (object) this.minor + ") on element of Version.minor.");
      this.release = (uint) reader.ReadByte();
      if (this.release < 0U)
        throw new Exception("Forbidden value (" + (object) this.release + ") on element of Version.release.");
      this.revision = (uint) reader.ReadInt();
      if (this.revision < 0U)
        throw new Exception("Forbidden value (" + (object) this.revision + ") on element of Version.revision.");
      this.patch = (uint) reader.ReadByte();
      if (this.patch < 0U)
        throw new Exception("Forbidden value (" + (object) this.patch + ") on element of Version.patch.");
      this.buildType = (uint) reader.ReadByte();
      if (this.buildType < 0U)
        throw new Exception("Forbidden value (" + (object) this.buildType + ") on element of Version.buildType.");
    }
  }
}
