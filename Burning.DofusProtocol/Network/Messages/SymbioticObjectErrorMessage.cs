using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class SymbioticObjectErrorMessage : ObjectErrorMessage
  {
    public new const uint Id = 6526;
    public int errorCode;

    public override uint MessageId
    {
      get
      {
        return 6526;
      }
    }

    public SymbioticObjectErrorMessage()
    {
    }

    public SymbioticObjectErrorMessage(int reason, int errorCode)
      : base(reason)
    {
      this.errorCode = errorCode;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteByte((byte) this.errorCode);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.errorCode = (int) reader.ReadByte();
    }
  }
}
