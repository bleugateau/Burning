using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class MountInformationsForPaddock
  {
    public const uint Id = 184;
    public uint modelId;
    public string name;
    public string ownerName;

    public virtual uint TypeId
    {
      get
      {
        return 184;
      }
    }

    public MountInformationsForPaddock()
    {
    }

    public MountInformationsForPaddock(uint modelId, string name, string ownerName)
    {
      this.modelId = modelId;
      this.name = name;
      this.ownerName = ownerName;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element modelId.");
      writer.WriteVarShort((short) this.modelId);
      writer.WriteUTF(this.name);
      writer.WriteUTF(this.ownerName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.modelId = (uint) reader.ReadVarUhShort();
      if (this.modelId < 0U)
        throw new Exception("Forbidden value (" + (object) this.modelId + ") on element of MountInformationsForPaddock.modelId.");
      this.name = reader.ReadUTF();
      this.ownerName = reader.ReadUTF();
    }
  }
}
