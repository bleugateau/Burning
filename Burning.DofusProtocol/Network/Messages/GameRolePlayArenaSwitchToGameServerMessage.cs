using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameRolePlayArenaSwitchToGameServerMessage : NetworkMessage
  {
    public List<int> ticket = new List<int>();
    public const uint Id = 6574;
    public bool validToken;
    public int homeServerId;

    public override uint MessageId
    {
      get
      {
        return 6574;
      }
    }

    public GameRolePlayArenaSwitchToGameServerMessage()
    {
    }

    public GameRolePlayArenaSwitchToGameServerMessage(
      bool validToken,
      List<int> ticket,
      int homeServerId)
    {
      this.validToken = validToken;
      this.ticket = ticket;
      this.homeServerId = homeServerId;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteBoolean(this.validToken);
      writer.WriteVarInt(this.ticket.Count);
      for (int index = 0; index < this.ticket.Count; ++index)
        writer.WriteByte((byte) this.ticket[index]);
      writer.WriteShort((short) this.homeServerId);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.validToken = reader.ReadBoolean();
      uint num = (uint) reader.ReadVarInt();
      for (int index = 0; (long) index < (long) num; ++index)
        this.ticket.Add((int) reader.ReadByte());
      this.homeServerId = (int) reader.ReadShort();
    }
  }
}
