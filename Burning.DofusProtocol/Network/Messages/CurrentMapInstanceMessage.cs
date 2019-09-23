using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class CurrentMapInstanceMessage : CurrentMapMessage
  {
    public new const uint Id = 6738;
    public double instantiatedMapId;

    public override uint MessageId
    {
      get
      {
        return 6738;
      }
    }

    public CurrentMapInstanceMessage()
    {
    }

    public CurrentMapInstanceMessage(double mapId, string mapKey, double instantiatedMapId)
      : base(mapId, mapKey)
    {
      this.instantiatedMapId = instantiatedMapId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.instantiatedMapId < 0.0 || this.instantiatedMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.instantiatedMapId + ") on element instantiatedMapId.");
      writer.WriteDouble(this.instantiatedMapId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.instantiatedMapId = reader.ReadDouble();
      if (this.instantiatedMapId < 0.0 || this.instantiatedMapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.instantiatedMapId + ") on element of CurrentMapInstanceMessage.instantiatedMapId.");
    }
  }
}
