using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class SimpleCharacterCharacteristicForPreset
  {
    public const uint Id = 541;
    public string keyword;
    public int @base;
    public int additionnal;

    public virtual uint TypeId
    {
      get
      {
        return 541;
      }
    }

    public SimpleCharacterCharacteristicForPreset()
    {
    }

    public SimpleCharacterCharacteristicForPreset(string keyword, int @base, int additionnal)
    {
      this.keyword = keyword;
      this.@base = @base;
      this.additionnal = additionnal;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      writer.WriteUTF(this.keyword);
      writer.WriteVarShort((short) this.@base);
      writer.WriteVarShort((short) this.additionnal);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.keyword = reader.ReadUTF();
      this.@base = (int) reader.ReadVarShort();
      this.additionnal = (int) reader.ReadVarShort();
    }
  }
}
