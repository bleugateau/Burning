using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class PlayerStatus
  {
    public const uint Id = 415;
    public uint statusId;

    public virtual uint TypeId
    {
      get
      {
        return 415;
      }
    }

    public PlayerStatus()
    {
    }

    public PlayerStatus(uint statusId)
    {
      this.statusId = statusId;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.statusId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.statusId = (uint) reader.ReadByte();
      if (this.statusId < 0U)
        throw new Exception("Forbidden value (" + (object) this.statusId + ") on element of PlayerStatus.statusId.");
    }
  }
}
