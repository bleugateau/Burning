using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PortalDialogCreationMessage : NpcDialogCreationMessage
  {
    public new const uint Id = 6737;
    public uint type;

    public override uint MessageId
    {
      get
      {
        return 6737;
      }
    }

    public PortalDialogCreationMessage()
    {
    }

    public PortalDialogCreationMessage(double mapId, int npcId, uint type)
      : base(mapId, npcId)
    {
      this.type = type;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteInt((int) this.type);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.type = (uint) reader.ReadInt();
      if (this.type < 0U)
        throw new Exception("Forbidden value (" + (object) this.type + ") on element of PortalDialogCreationMessage.type.");
    }
  }
}
