using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeSetCraftRecipeMessage : NetworkMessage
  {
    public const uint Id = 6389;
    public uint objectGID;

    public override uint MessageId
    {
      get
      {
        return 6389;
      }
    }

    public ExchangeSetCraftRecipeMessage()
    {
    }

    public ExchangeSetCraftRecipeMessage(uint objectGID)
    {
      this.objectGID = objectGID;
    }

    public override void Serialize(IDataWriter writer)
    {
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element objectGID.");
      writer.WriteVarShort((short) this.objectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
      this.objectGID = (uint) reader.ReadVarUhShort();
      if (this.objectGID < 0U)
        throw new Exception("Forbidden value (" + (object) this.objectGID + ") on element of ExchangeSetCraftRecipeMessage.objectGID.");
    }
  }
}
