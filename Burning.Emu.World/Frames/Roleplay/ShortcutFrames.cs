using Burning.Common.Managers.Frame;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Enums;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.Emu.World.Repository;

namespace Burning.Emu.World.Frames.Roleplay
{
    public class ShortcutFrames : Frame
    {
        [PacketId(ShortcutBarAddRequestMessage.Id)]
        public void ShortcutBarAddRequestMessageFrame(WorldClient client, ShortcutBarAddRequestMessage shortcutBarAddRequestMessage)
        {
            var shortcutsBars = client.ActiveCharacter.CharacterShortcutBars;

            if (shortcutsBars == null)
                return;

            switch((ShortcutBarEnum)shortcutBarAddRequestMessage.barType)
            {
                case ShortcutBarEnum.GENERAL_SHORTCUT_BAR:
                    //check si bien un object (preset, ensemble, objet)
                    if (!(shortcutBarAddRequestMessage.shortcut is ShortcutObject))
                        return;

                    var generalBarShortcut = shortcutsBars.Find(x => x.BarType == ShortcutBarEnum.GENERAL_SHORTCUT_BAR);

                    CharacterShortcutRepository.Instance.AddShortcutObject(generalBarShortcut, shortcutBarAddRequestMessage.shortcut);
                    break;
                case ShortcutBarEnum.SPELL_SHORTCUT_BAR:
                    //check si bien un spell
                    if (!(shortcutBarAddRequestMessage.shortcut is ShortcutSpell))
                        return;

                    var spellBarShortcut = shortcutsBars.Find(x => x.BarType == ShortcutBarEnum.SPELL_SHORTCUT_BAR);

                    CharacterShortcutRepository.Instance.AddShortcutObject(spellBarShortcut, shortcutBarAddRequestMessage.shortcut);
                    break;
                default:
                    client.SendPacket(new ShortcutBarAddErrorMessage(1));
                    return;
            }

            client.SendPacket(new ShortcutBarRefreshMessage(shortcutBarAddRequestMessage.barType, shortcutBarAddRequestMessage.shortcut));
        }

        [PacketId(ShortcutBarRemoveRequestMessage.Id)]
        public void ShortcutBarRemoveRequestMessageFrame(WorldClient client, ShortcutBarRemoveRequestMessage shortcutBarRemoveRequestMessage)
        {
            var shortcutsBars = client.ActiveCharacter.CharacterShortcutBars;

            if (shortcutsBars == null)
                return;


            var shortcutBar = shortcutsBars.Find(x => x.BarType == (ShortcutBarEnum)shortcutBarRemoveRequestMessage.barType);

            CharacterShortcutRepository.Instance.RemoveShortcut(shortcutBar, (int)shortcutBarRemoveRequestMessage.slot);

            client.SendPacket(new ShortcutBarRemovedMessage(shortcutBarRemoveRequestMessage.barType, shortcutBarRemoveRequestMessage.slot));
        }
    }
}
