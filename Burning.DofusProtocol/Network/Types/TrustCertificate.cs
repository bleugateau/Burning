using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class TrustCertificate
  {
    public const uint Id = 377;
    public uint id;
    public string hash;

    public virtual uint TypeId
    {
      get
      {
        return 377;
      }
    }

    public TrustCertificate()
    {
    }

    public TrustCertificate(uint id, string hash)
    {
      this.id = id;
      this.hash = hash;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteInt((int) this.id);
      writer.WriteUTF(this.hash);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (uint) reader.ReadInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of TrustCertificate.id.");
      this.hash = reader.ReadUTF();
    }
  }
}
