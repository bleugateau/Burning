using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Shapes
{
    public class RawZone
    {

        public int m_zoneShape;
        public uint m_zoneSize;
        public uint m_zoneMinSize;

        public RawZone(string rawZone)
        {
            if (string.IsNullOrEmpty(rawZone))
            {
                m_zoneShape = 0;
                m_zoneSize = 0;
                m_zoneMinSize = 0;
                return;
            }

            var shape = (SpellShapeEnum)rawZone[0];
            byte size = 0;
            byte minSize = 0;

            var data = rawZone.Remove(0, 1).Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var hasMinSize = shape == SpellShapeEnum.C || shape == SpellShapeEnum.X || shape == SpellShapeEnum.Q || shape == SpellShapeEnum.plus || shape == SpellShapeEnum.sharp;

            /*
            try
            {
                if (data.Length >= 4)
                {
                    size = byte.Parse(data[0]);
                    minSize = byte.Parse(data[1]);
                }
                else
                {
                    if (data.Length >= 1)
                        size = byte.Parse(data[0]);

                    if (data.Length >= 2)
                        if (hasMinSize)
                            minSize = byte.Parse(data[1]);
                }
            }
            catch (Exception ex)
            {
                m_zoneShape = 0;
                m_zoneSize = 0;
                m_zoneMinSize = 0;
            }

    */
            try
            {
                size = byte.Parse(data[0]);
                minSize = byte.Parse(data[1]);
            }
            catch
            {
                m_zoneShape = 0;
                m_zoneSize = 0;
                m_zoneMinSize = 0;
            }

            m_zoneShape = (int)shape;
            m_zoneSize = size;
            m_zoneMinSize = minSize;
        }
    }
}
