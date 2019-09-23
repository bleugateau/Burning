using FlatyBot.Common.IO;

namespace Burning.DofusProtocol.Network.Types
{
  public class ActorRestrictionsInformations
  {
    public const uint Id = 204;
    public bool cantBeAggressed;
    public bool cantBeChallenged;
    public bool cantTrade;
    public bool cantBeAttackedByMutant;
    public bool cantRun;
    public bool forceSlowWalk;
    public bool cantMinimize;
    public bool cantMove;
    public bool cantAggress;
    public bool cantChallenge;
    public bool cantExchange;
    public bool cantAttack;
    public bool cantChat;
    public bool cantBeMerchant;
    public bool cantUseObject;
    public bool cantUseTaxCollector;
    public bool cantUseInteractive;
    public bool cantSpeakToNPC;
    public bool cantChangeZone;
    public bool cantAttackMonster;
    public bool cantWalk8Directions;

    public virtual uint TypeId
    {
      get
      {
        return 204;
      }
    }

    public ActorRestrictionsInformations()
    {
    }

    public ActorRestrictionsInformations(
      bool cantBeAggressed,
      bool cantBeChallenged,
      bool cantTrade,
      bool cantBeAttackedByMutant,
      bool cantRun,
      bool forceSlowWalk,
      bool cantMinimize,
      bool cantMove,
      bool cantAggress,
      bool cantChallenge,
      bool cantExchange,
      bool cantAttack,
      bool cantChat,
      bool cantBeMerchant,
      bool cantUseObject,
      bool cantUseTaxCollector,
      bool cantUseInteractive,
      bool cantSpeakToNPC,
      bool cantChangeZone,
      bool cantAttackMonster,
      bool cantWalk8Directions)
    {
      this.cantBeAggressed = cantBeAggressed;
      this.cantBeChallenged = cantBeChallenged;
      this.cantTrade = cantTrade;
      this.cantBeAttackedByMutant = cantBeAttackedByMutant;
      this.cantRun = cantRun;
      this.forceSlowWalk = forceSlowWalk;
      this.cantMinimize = cantMinimize;
      this.cantMove = cantMove;
      this.cantAggress = cantAggress;
      this.cantChallenge = cantChallenge;
      this.cantExchange = cantExchange;
      this.cantAttack = cantAttack;
      this.cantChat = cantChat;
      this.cantBeMerchant = cantBeMerchant;
      this.cantUseObject = cantUseObject;
      this.cantUseTaxCollector = cantUseTaxCollector;
      this.cantUseInteractive = cantUseInteractive;
      this.cantSpeakToNPC = cantSpeakToNPC;
      this.cantChangeZone = cantChangeZone;
      this.cantAttackMonster = cantAttackMonster;
      this.cantWalk8Directions = cantWalk8Directions;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      int num1 = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.cantBeAggressed), (byte) 1, this.cantBeChallenged), (byte) 2, this.cantTrade), (byte) 3, this.cantBeAttackedByMutant), (byte) 4, this.cantRun), (byte) 5, this.forceSlowWalk), (byte) 6, this.cantMinimize), (byte) 7, this.cantMove);
      writer.WriteByte((byte) num1);
      int num2 = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.cantAggress), (byte) 1, this.cantChallenge), (byte) 2, this.cantExchange), (byte) 3, this.cantAttack), (byte) 4, this.cantChat), (byte) 5, this.cantBeMerchant), (byte) 6, this.cantUseObject), (byte) 7, this.cantUseTaxCollector);
      writer.WriteByte((byte) num2);
      int num3 = (int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag((int) Burning.DofusProtocol.Network.BooleanByteWrapper.SetFlag(0, (byte) 0, this.cantUseInteractive), (byte) 1, this.cantSpeakToNPC), (byte) 2, this.cantChangeZone), (byte) 3, this.cantAttackMonster), (byte) 4, this.cantWalk8Directions);
      writer.WriteByte((byte) num3);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      uint num1 = (uint) reader.ReadByte();
      this.cantBeAggressed = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 0);
      this.cantBeChallenged = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 1);
      this.cantTrade = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 2);
      this.cantBeAttackedByMutant = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 3);
      this.cantRun = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 4);
      this.forceSlowWalk = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 5);
      this.cantMinimize = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 6);
      this.cantMove = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num1, (byte) 7);
      uint num2 = (uint) reader.ReadByte();
      this.cantAggress = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 0);
      this.cantChallenge = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 1);
      this.cantExchange = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 2);
      this.cantAttack = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 3);
      this.cantChat = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 4);
      this.cantBeMerchant = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 5);
      this.cantUseObject = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 6);
      this.cantUseTaxCollector = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num2, (byte) 7);
      uint num3 = (uint) reader.ReadByte();
      this.cantUseInteractive = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num3, (byte) 0);
      this.cantSpeakToNPC = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num3, (byte) 1);
      this.cantChangeZone = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num3, (byte) 2);
      this.cantAttackMonster = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num3, (byte) 3);
      this.cantWalk8Directions = Burning.DofusProtocol.Network.BooleanByteWrapper.GetFlag((byte) num3, (byte) 4);
    }
  }
}
