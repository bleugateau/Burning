using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class UpdateMountCharacteristic
  {
    public const uint Id = 536;
    public uint type;

    public virtual uint TypeId
    {
      get
      {
        return 536;
      }
    }

    public UpdateMountCharacteristic()
    {
    }

    public UpdateMountCharacteristic(uint type)
    {
      this.type = type;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteByte((byte) this.type);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.type = (uint) reader.ReadByte();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of UpdateMountCharacteristic.type.");
    }
  }
}
