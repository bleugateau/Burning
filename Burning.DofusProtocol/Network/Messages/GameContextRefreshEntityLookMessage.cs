using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class GameContextRefreshEntityLookMessage : NetworkMessage
  {
    public const uint Id = 5637;
    public double id;
    public EntityLook look;

    public override uint MessageId
    {
      get
      {
        return 5637;
      }
    }

    public GameContextRefreshEntityLookMessage()
    {
    }

    public GameContextRefreshEntityLookMessage(double id, EntityLook look)
    {
      this.id = id;
      this.look = look;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteDouble(this.id);
      this.look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.id = reader.ReadDouble();
      if (this.id < -9.00719925474099E+15 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of GameContextRefreshEntityLookMessage.id.");
      this.look = new EntityLook();
      this.look.Deserialize(reader);
    }
  }
}
