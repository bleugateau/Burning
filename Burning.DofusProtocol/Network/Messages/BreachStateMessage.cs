using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class BreachStateMessage : NetworkMessage
  {
    public List<ObjectEffectInteger> bonuses = new List<ObjectEffectInteger>();
    public const uint Id = 6799;
    public CharacterMinimalInformations owner;
    public uint bugdet;
    public bool saved;

    public override uint MessageId
    {
      get
      {
        return 6799;
      }
    }

    public BreachStateMessage()
    {
    }

    public BreachStateMessage(
      CharacterMinimalInformations owner,
      List<ObjectEffectInteger> bonuses,
      uint bugdet,
      bool saved)
    {
      this.owner = owner;
      this.bonuses = bonuses;
      this.bugdet = bugdet;
      this.saved = saved;
    }

    public override void Serialize(IDataWriter writer)
    {
      this.owner.Serialize(writer);
      writer.WriteShort((short) this.bonuses.Count);
      for (int index = 0; index < this.bonuses.Count; ++index)
        this.bonuses[index].Serialize(writer);
      if (this.bugdet < 0U)
        throw new Exception("Forbidden value (" + (object) this.bugdet + ") on element bugdet.");
      writer.WriteVarInt((int) this.bugdet);
      writer.WriteBoolean(this.saved);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.owner = new CharacterMinimalInformations();
      this.owner.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        ObjectEffectInteger objectEffectInteger = new ObjectEffectInteger();
        objectEffectInteger.Deserialize(reader);
        this.bonuses.Add(objectEffectInteger);
      }
      this.bugdet = reader.ReadVarUhInt();
      if (this.bugdet < 0U)
        throw new Exception("Forbidden value (" + (object) this.bugdet + ") on element of BreachStateMessage.bugdet.");
      this.saved = reader.ReadBoolean();
    }
  }
}
