using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionTitle : HumanOption
  {
    public new const uint Id = 408;
    public uint titleId;
    public string titleParam;

    public override uint TypeId
    {
      get
      {
        return 408;
      }
    }

    public HumanOptionTitle()
    {
    }

    public HumanOptionTitle(uint titleId, string titleParam)
    {
      this.titleId = titleId;
      this.titleParam = titleParam;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.titleId < 0U)
        throw new Exception("Forbidden value (" + (object) this.titleId + ") on element titleId.");
      writer.WriteVarShort((short) this.titleId);
      writer.WriteUTF(this.titleParam);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.titleId = (uint) reader.ReadVarUhShort();
      if (this.titleId < 0U)
        throw new Exception("Forbidden value (" + (object) this.titleId + ") on element of HumanOptionTitle.titleId.");
      this.titleParam = reader.ReadUTF();
    }
  }
}
