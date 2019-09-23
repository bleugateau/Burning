using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AbstractContactInformations
  {
    public const uint Id = 380;
    public uint accountId;
    public string accountName;

    public virtual uint TypeId
    {
      get
      {
        return 380;
      }
    }

    public AbstractContactInformations()
    {
    }

    public AbstractContactInformations(uint accountId, string accountName)
    {
      this.accountId = accountId;
      this.accountName = accountName;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element accountId.");
      writer.WriteInt((int) this.accountId);
      writer.WriteUTF(this.accountName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.accountId = (uint) reader.ReadInt();
      if (this.accountId < 0U)
        throw new Exception("Forbidden value (" + (object) this.accountId + ") on element of AbstractContactInformations.accountId.");
      this.accountName = reader.ReadUTF();
    }
  }
}
