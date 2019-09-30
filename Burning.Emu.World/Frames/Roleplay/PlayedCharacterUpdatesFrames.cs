using Burning.Common.Managers.Frame;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Emu.World.Network;
using Burning.Common.Repository;
using System.Linq;
using Burning.Emu.World.Repository;

namespace Burning.Emu.World.Frames.Roleplay
{
    public class PlayedCharacterUpdatesFrames : Frame
    {
        [PacketId(StatsUpgradeRequestMessage.Id)]
        public void StatsUpgradeRequestMessageFrame(WorldClient client, StatsUpgradeRequestMessage statsUpgradeRequestMessage)
        {
            if (client.ActiveCharacter == null)
                return;

            if(!CharacterCharacteristicRepository.Instance.StatsUpgradeRequestAction(client.ActiveCharacter, statsUpgradeRequestMessage.boostPoint, statsUpgradeRequestMessage.statId))
            {
                client.SendPacket(new StatsUpgradeResultMessage((int)StatsUpgradeResultEnum.NOT_ENOUGH_POINT, 0));
                client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));
                return;
            }

            client.SendPacket(new StatsUpgradeResultMessage((int)StatsUpgradeResultEnum.SUCCESS, statsUpgradeRequestMessage.boostPoint));
            client.SendPacket(new CharacterStatsListMessage(client.ActiveCharacter.GetCharacterCharacteristicsInformations()));
        }
    }
}
