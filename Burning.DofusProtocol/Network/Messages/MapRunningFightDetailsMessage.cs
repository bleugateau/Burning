using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class MapRunningFightDetailsMessage : NetworkMessage
  {
    public List<GameFightFighterLightInformations> attackers = new List<GameFightFighterLightInformations>();
    public List<GameFightFighterLightInformations> defenders = new List<GameFightFighterLightInformations>();
    public const uint Id = 5751;
    public uint fightId;

    public override uint MessageId
    {
      get
      {
        return 5751;
      }
    }

    public MapRunningFightDetailsMessage()
    {
    }

    public MapRunningFightDetailsMessage(
      uint fightId,
      List<GameFightFighterLightInformations> attackers,
      List<GameFightFighterLightInformations> defenders)
    {
      this.fightId = fightId;
      this.attackers = attackers;
      this.defenders = defenders;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element fightId.");
      writer.WriteVarShort((short) this.fightId);
      writer.WriteShort((short) this.attackers.Count);
      for (int index = 0; index < this.attackers.Count; ++index)
      {
        writer.WriteShort((short) this.attackers[index].TypeId);
        this.attackers[index].Serialize(writer);
      }
      writer.WriteShort((short) this.defenders.Count);
      for (int index = 0; index < this.defenders.Count; ++index)
      {
        writer.WriteShort((short) this.defenders[index].TypeId);
        this.defenders[index].Serialize(writer);
      }
    }

    public override void Deserialize(IDataReader reader)
    {
      this.fightId = (uint) reader.ReadVarUhShort();
      if (this.fightId < 0U)
        throw new Exception("Forbidden value (" + (object) this.fightId + ") on element of MapRunningFightDetailsMessage.fightId.");
      uint num1 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num1; ++index)
      {
        GameFightFighterLightInformations instance = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.attackers.Add(instance);
      }
      uint num2 = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num2; ++index)
      {
        GameFightFighterLightInformations instance = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>((uint) reader.ReadUShort());
        instance.Deserialize(reader);
        this.defenders.Add(instance);
      }
    }
  }
}
