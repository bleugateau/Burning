using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ContactLookMessage : NetworkMessage
  {
    public const uint Id = 5934;
    public uint requestId;
    public string playerName;
    public double playerId;
    public EntityLook look;

    public override uint MessageId
    {
      get
      {
        return 5934;
      }
    }

    public ContactLookMessage()
    {
    }

    public ContactLookMessage(uint requestId, string playerName, double playerId, EntityLook look)
    {
      this.requestId = requestId;
      this.playerName = playerName;
      this.playerId = playerId;
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element requestId.");
      writer.WriteVarInt((int) this.requestId);
      writer.WriteUTF(this.playerName);
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element playerId.");
      writer.WriteVarLong((long) this.playerId);
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.requestId = reader.ReadVarUhInt();
      if (this.requestId < 0U)
        throw new Exception("Forbidden value (" + (object) this.requestId + ") on element of ContactLookMessage.requestId.");
      this.playerName = reader.ReadUTF();
      this.playerId = (double) reader.ReadVarUhLong();
      if (this.playerId < 0.0 || this.playerId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.playerId + ") on element of ContactLookMessage.playerId.");
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
