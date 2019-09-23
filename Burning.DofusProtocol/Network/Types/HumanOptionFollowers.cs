using FlatyBot.Common.IO;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Types
{
  public class HumanOptionFollowers : HumanOption
  {
    public List<IndexedEntityLook> followingCharactersLook = new List<IndexedEntityLook>();
    public new const uint Id = 410;

    public override uint TypeId
    {
      get
      {
        return 410;
      }
    }

    public HumanOptionFollowers()
    {
    }

    public HumanOptionFollowers(List<IndexedEntityLook> followingCharactersLook)
    {
      this.followingCharactersLook = followingCharactersLook;
    }

    public override void Serialize(IDataWriter writer)
    {
      base.Serialize(writer);
      writer.WriteShort((short) this.followingCharactersLook.Count);
      for (int index = 0; index < this.followingCharactersLook.Count; ++index)
        this.followingCharactersLook[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      base.Deserialize(reader);
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        IndexedEntityLook indexedEntityLook = new IndexedEntityLook();
        indexedEntityLook.Deserialize(reader);
        this.followingCharactersLook.Add(indexedEntityLook);
      }
    }
  }
}
