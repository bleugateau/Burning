using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
  public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
  {
    public new const uint Id = 5669;
    public double mapId;
    public uint elementId;

    public override uint MessageId
    {
      get
      {
        return 5669;
      }
    }

    public LockableStateUpdateStorageMessage()
    {
    }

    public LockableStateUpdateStorageMessage(bool locked, double mapId, uint elementId)
      : base(locked)
    {
      this.mapId = mapId;
      this.elementId = elementId;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element mapId.");
      writer.WriteDouble(this.mapId);
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element elementId.");
      writer.WriteVarInt((int) this.elementId);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      this.mapId = reader.ReadDouble();
      if (this.mapId < 0.0 || this.mapId > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.mapId + ") on element of LockableStateUpdateStorageMessage.mapId.");
      this.elementId = reader.ReadVarUhInt();
      if (this.elementId < 0U)
        throw new Exception("Forbidden value (" + (object) this.elementId + ") on element of LockableStateUpdateStorageMessage.elementId.");
    }
  }
}
