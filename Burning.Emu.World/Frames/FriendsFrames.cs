using Burning.Common.Entity;
using Burning.Common.Managers.Frame;
using Burning.Common.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Network.Types;

namespace Burning.Emu.World.Frames
{
    public class FriendsFrames : Frame
    {
        [PacketId(FriendsGetListMessage.Id)]
        public void FriendsGetListMessageFrame(WorldClient client, FriendsGetListMessage friendsGetListMessage)
        {
            client.SendPacket(new FriendsListMessage(new List<FriendInformations>())); //friends
        }

        [PacketId(AcquaintancesGetListMessage.Id)]
        public void AcquaintancesGetListMessageFrame(WorldClient client, AcquaintancesGetListMessage acquaintancesGetListMessage)
        {
            client.SendPacket(new AcquaintancesListMessage(new List<AcquaintanceInformation>())); //contact=non addded friends
        }

        [PacketId(IgnoredGetListMessage.Id)]
        public void IgnoredGetListMessageFrame(WorldClient client, IgnoredGetListMessage ignoredGetListMessage)
        {
            client.SendPacket(new IgnoredListMessage(new List<IgnoredInformations>())); //ignored friends
        }
    }
}
