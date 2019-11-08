using Burning.DofusProtocol.Network.Messages;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Interactive.Skills
{
    public class ZaapSkill : Skill
    {
        [SkillAttribute(114)]
        public ZaapSkill(int skillId, WorldClient client) : base(skillId, client)
        {
            Console.WriteLine("Zaap todo");
        }

        public override void Execute()
        {
            //boom
            Client.SendPacket(new InteractiveUsedMessage(Client.ActiveCharacter.Id, 0, 114, 0, true));
            Client.SendPacket(new ZaapDestinationsMessage(0, new List<DofusProtocol.Network.Types.TeleportDestination>(), 0));
            
        }
    }
}
