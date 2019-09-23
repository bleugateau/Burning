using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MimicryObjectErrorMessage : SymbioticObjectErrorMessage
  {
    public new const uint Id = 6461;
    public bool preview;

    public override uint MessageId
    {
      get
      {
        return 6461;
      }
    }

    public MimicryObjectErrorMessage()
    {
    }

    public MimicryObjectErrorMessage(int reason, int errorCode, bool preview)
      : base(reason, errorCode)
    {
      this.preview = preview;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteBoolean(this.preview);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.preview = reader.ReadBoolean();
    }
  }
}
