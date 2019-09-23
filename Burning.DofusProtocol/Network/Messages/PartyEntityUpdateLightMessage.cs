using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class PartyEntityUpdateLightMessage : PartyUpdateLightMessage
  {
    public new const uint Id = 6781;
    public uint indexId;

    public override uint MessageId
    {
      get
      {
        return 6781;
      }
    }

    public PartyEntityUpdateLightMessage()
    {
    }

    public PartyEntityUpdateLightMessage(
      uint partyId,
      double id,
      uint lifePoints,
      uint maxLifePoints,
      uint prospecting,
      uint regenRate,
      uint indexId)
      : base(partyId, id, lifePoints, maxLifePoints, prospecting, regenRate)
    {
      this.indexId = indexId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.indexId < 0U)
        throw new Exception("Forbidden value (" + (object) this.indexId + ") on element indexId.");
      writer.WriteByte((byte) this.indexId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.indexId = (uint) reader.ReadByte();
      if (this.indexId < 0U)
        throw new Exception("Forbidden value (" + (object) this.indexId + ") on element of PartyEntityUpdateLightMessage.indexId.");
    }
  }
}
