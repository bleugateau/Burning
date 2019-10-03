using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;

namespace Burning.DofusProtocol.Network.Messages
{
    public class GameFightPlacementPositionRequestMessage : NetworkMessage
    {
        public const uint Id = 704;
        public uint cellId;

        public override uint MessageId
        {
            get
            {
                return 704;
            }
        }

        public GameFightPlacementPositionRequestMessage()
        {
        }

        public GameFightPlacementPositionRequestMessage(uint cellId)
        {
            this.cellId = cellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            if (this.cellId < 0U || this.cellId > 559U)
                throw new Exception("Forbidden value (" + (object)this.cellId + ") on element cellId.");
            writer.WriteVarShort((short)this.cellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            this.cellId = (uint)reader.ReadVarUhShort();
            if (this.cellId < 0U || this.cellId > 559U)
                throw new Exception("Forbidden value (" + (object)this.cellId + ") on element of GameFightPlacementPositionRequestMessage.cellId.");
        }
    }
}
