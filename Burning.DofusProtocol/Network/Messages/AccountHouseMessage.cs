using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class AccountHouseMessage : NetworkMessage
  {
    public List<AccountHouseInformations> houses = new List<AccountHouseInformations>();
    public const uint Id = 6315;

    public override uint MessageId
    {
      get
      {
        return 6315;
      }
    }

    public AccountHouseMessage()
    {
    }

    public AccountHouseMessage(List<AccountHouseInformations> houses)
    {
      this.houses = houses;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.houses.Count);
      for (int index = 0; index < this.houses.Count; ++index)
        this.houses[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        AccountHouseInformations houseInformations = new AccountHouseInformations();
        houseInformations.Deserialize(reader);
        this.houses.Add(houseInformations);
      }
    }
  }
}
