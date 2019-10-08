using FlatyBot.Common.IO;
using System;

namespace Burning.DofusProtocol.Network.Types
{
    public class GameContextActorPositionInformations
    {
        public const uint Id = 566;
        public double contextualId;
        public EntityDispositionInformations disposition;

        public virtual uint TypeId
        {
            get
            {
                return 566;
            }
        }

        public GameContextActorPositionInformations()
        {
        }

        public GameContextActorPositionInformations(
          double contextualId,
          EntityDispositionInformations disposition)
        {
            this.contextualId = contextualId;
            this.disposition = disposition;
        }

        public virtual void Serialize(IDataWriter writer)
        {
            if (this.contextualId < -9.00719925474099E+15 || this.contextualId > 9.00719925474099E+15)
                throw new Exception("Forbidden value (" + (object)this.contextualId + ") on element contextualId.");
            writer.WriteDouble(this.contextualId);
            writer.WriteShort((short)this.disposition.TypeId);
            this.disposition.Serialize(writer);
        }

        public virtual void Deserialize(IDataReader reader)
        {
            this.contextualId = reader.ReadDouble();
            if (this.contextualId < -9.00719925474099E+15 || this.contextualId > 9.00719925474099E+15)
                throw new Exception("Forbidden value (" + (object)this.contextualId + ") on element of GameContextActorPositionInformations.contextualId.");
            this.disposition = ProtocolTypeManager.GetInstance<EntityDispositionInformations>((uint)reader.ReadUShort());
            this.disposition.Deserialize(reader);
        }
    }
}
