using FlatyBot.Common.IO;
using FlatyBot.Common.Network;
using System;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Network.Messages
{
    public class GameMapMovementMessage : NetworkMessage
    {
        public List<uint> keyMovements = new List<uint>();
        public const uint Id = 951;
        public int forcedDirection;
        public double actorId;

        public override uint MessageId
        {
            get
            {
                return 951;
            }
        }

        public GameMapMovementMessage()
        {
        }

        public GameMapMovementMessage(List<uint> keyMovements, int forcedDirection, double actorId)
        {
            this.keyMovements = keyMovements;
            this.forcedDirection = forcedDirection;
            this.actorId = actorId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)this.keyMovements.Count);
            for (int index = 0; index < this.keyMovements.Count; ++index)
            {
                if (this.keyMovements[index] < 0U)
                    throw new Exception("Forbidden value (" + (object)this.keyMovements[index] + ") on element 1 (starting at 1) of keyMovements.");
                writer.WriteShort((short)this.keyMovements[index]);
            }
            writer.WriteShort((short)this.forcedDirection);
            if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
                throw new Exception("Forbidden value (" + (object)this.actorId + ") on element actorId.");
            writer.WriteDouble(this.actorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            uint num1 = (uint)reader.ReadUShort();
            for (int index = 0; (long)index < (long)num1; ++index)
            {
                uint num2 = (uint)reader.ReadShort();
                if (num2 < 0U)
                    throw new Exception("Forbidden value (" + (object)num2 + ") on elements of keyMovements.");
                this.keyMovements.Add(num2);
            }
            this.forcedDirection = (int)reader.ReadShort();
            this.actorId = reader.ReadDouble();
            if (this.actorId < -9.00719925474099E+15 || this.actorId > 9.00719925474099E+15)
                throw new Exception("Forbidden value (" + (object)this.actorId + ") on element of GameMapMovementMessage.actorId.");
        }
    }
}
