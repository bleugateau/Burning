using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using Burning.DofusProtocol.Network.Types;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
  public class StartupActionsListMessage : NetworkMessage
  {
    public List<StartupActionAddObject> actions = new List<StartupActionAddObject>();
    public const uint Id = 1301;

    public override uint MessageId
    {
      get
      {
        return 1301;
      }
    }

    public StartupActionsListMessage()
    {
    }

    public StartupActionsListMessage(List<StartupActionAddObject> actions)
    {
      this.actions = actions;
    }

    public override void Serialize(IDataWriter writer)
    {
      writer.WriteShort((short) this.actions.Count);
      for (int index = 0; index < this.actions.Count; ++index)
        this.actions[index].Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
      uint num = (uint) reader.ReadUShort();
      for (int index = 0; (long) index < (long) num; ++index)
      {
        StartupActionAddObject startupActionAddObject = new StartupActionAddObject();
        startupActionAddObject.Deserialize(reader);
        this.actions.Add(startupActionAddObject);
      }
    }
  }
}
