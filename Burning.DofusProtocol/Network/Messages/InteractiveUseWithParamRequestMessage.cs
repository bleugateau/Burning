using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Messages
{
  public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
  {
    public new const uint Id = 6715;
    public int id;

    public override uint MessageId
    {
      get
      {
        return 6715;
      }
    }

    public InteractiveUseWithParamRequestMessage()
    {
    }

    public InteractiveUseWithParamRequestMessage(uint elemId, uint skillInstanceUid, int id)
      : base(elemId, skillInstanceUid)
    {
      this.id = id;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt(this.id);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.id = reader.ReadInt();
    }
  }
}
