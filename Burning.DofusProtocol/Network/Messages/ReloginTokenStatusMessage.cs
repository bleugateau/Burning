using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ReloginTokenStatusMessage : NetworkMessage
  {
    public List<int> ticket = new List<int>();
    public const uint Id = 6539;
    public bool validToken;

    public override uint MessageId
    {
      get
      {
        return 6539;
      }
    }

    public ReloginTokenStatusMessage()
    {
    }

    public ReloginTokenStatusMessage(bool validToken, List<int> ticket)
    {
      this.validToken = validToken;
      this.ticket = ticket;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.validToken);
      writer.WriteVarInt(this.ticket.Count);
      for (int index = 0; index < this.ticket.Count; ++index)
        writer.WriteByte((byte) this.ticket[index]);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.validToken = reader.ReadBoolean();
      uint num = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num; ++index)
        this.ticket.Add((int) reader.ReadByte());
    }
  }
}
