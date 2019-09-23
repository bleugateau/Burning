using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
  public class AbstractCharacterInformation
  {
    public const uint Id = 400;
    public double id;

    public virtual uint TypeId
    {
      get
      {
        return 400;
      }
    }

    public AbstractCharacterInformation()
    {
    }

    public AbstractCharacterInformation(double id)
    {
      this.id = id;
    }

    public virtual void Serialize(IDataWriter writer)
    {
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element id.");
      writer.WriteVarLong((long) this.id);
    }

    public virtual void Deserialize(IDataReader reader)
    {
      this.id = (double) reader.ReadVarUhLong();
      if (this.id < 0.0 || this.id > 9.00719925474099E+15)
        throw new Exception("Forbidden value (" + (object) this.id + ") on element of AbstractCharacterInformation.id.");
    }
  }
}
