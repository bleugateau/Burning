using FlatyBot.Common.IO;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
  {
    public new const uint Id = 6557;

    public override uint MessageId
    {
      get
      {
        return 6557;
      }
    }

    public ExchangeMountsStableBornAddMessage()
    {
    }

    public ExchangeMountsStableBornAddMessage(List<MountClientData> mountDescription)
      : base(mountDescription)
    {
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
    }
  }
}
