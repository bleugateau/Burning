using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachRewardBoughtMessage : NetworkMessage
  {
    public const uint Id = 6797;
    public uint id;
    public bool bought;

    public override uint MessageId
    {
      get
      {
        return 6797;
      }
    }

    public BreachRewardBoughtMessage()
    {
    }

    public BreachRewardBoughtMessage(uint id, bool bought)
    {
      this.id = id;
      this.bought = bought;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarInt((int) this.id);
      writer.WriteBoolean(this.bought);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadVarUhInt();
      if (this.id < 0U)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of BreachRewardBoughtMessage.id.");
      this.bought = reader.ReadBoolean();
    }
  }
}
