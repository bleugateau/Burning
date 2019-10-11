using Burning.Common.Repository;
using Burning.DofusProtocol.Data.D2o.other;
using Burning.DofusProtocol.Data.D2P;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Spell
{
    public static class SpellRangeManager
    {
        public static SpellInabilityReason CanLaunchSpell(List<int> takenCellIds, int spellId, int characterCellId, int cellId)
        {
            var spellData = SpellRepository.Instance.GetSpellById(spellId);
            var spellLevelsData = SpellLevelRepository.Instance.GetSpellLevelById((int)spellData.SpellLevels[0]);

            bool isFreeCell = false;

            if (spellLevelsData == null)
                return SpellInabilityReason.Unknown;

            MapPoint characterPoint = new MapPoint(characterCellId);
            MapPoint targetPoint = new MapPoint(cellId);
            int distanceToTarget = characterPoint.DistanceToCell(targetPoint);
            int minRange = (spellId != 0) ? (int)spellLevelsData.MinRange : 0; //weaponData.minRange;
            if ((spellId != 0 && (bool)spellLevelsData.CastInDiagonal))// || (weaponData != null && weaponData.castInDiagonal))
                minRange = (minRange * 2);
            if (minRange < 0)
                minRange = 0;
            int maxRange = (spellId != 0) ? (int)((int)spellLevelsData.Range + ((bool)spellLevelsData.RangeCanBeBoosted ? /* Account.CharacterStats.range.objectsAndMountBonus */ 0 : 0)) : (int)spellLevelsData.Range;
            if ((spellId != 0 && (bool)spellLevelsData.CastInDiagonal))// || (weaponData != null && weaponData.castInDiagonal))
                maxRange = (maxRange * 2);
            if (maxRange < 0)
                maxRange = 0;
            if (distanceToTarget < minRange && distanceToTarget > 0)
                return SpellInabilityReason.MinRange;
            if (distanceToTarget > maxRange)
                return SpellInabilityReason.MaxRange;
            if (((spellId != 0 && (bool)spellLevelsData.CastInLine))// || (weaponData != null && weaponData.castInDiagonal)) &&
               && characterPoint.X != targetPoint.X &&
                characterPoint.Y != targetPoint.Y)
                return SpellInabilityReason.NotInLine;
            if ((spellId != 0 && (bool)spellLevelsData.CastInDiagonal))// || (weaponData != null && weaponData.castInDiagonal))
            {
                ArrayList list = Dofus1Line.GetLine(characterPoint.X, characterPoint.Y, targetPoint.X, targetPoint.Y);

                int i = 0;
                while (i < list.Count - 1)
                {
                    Dofus1Line.Point actualPoint = (Dofus1Line.Point)list[i];
                    Dofus1Line.Point nextPoint = (Dofus1Line.Point)list[i + 1];
                    i += 1;
                    if (actualPoint.X == nextPoint.X + 1 && actualPoint.Y == nextPoint.Y + 1)
                        continue;
                    else if (actualPoint.X == nextPoint.X - 1 && actualPoint.Y == nextPoint.Y - 1)
                        continue;
                    else if (actualPoint.X == nextPoint.X + 1 && actualPoint.Y == nextPoint.Y - 1)
                        continue;
                    else if (actualPoint.X == nextPoint.X - 1 && actualPoint.Y == nextPoint.Y + 1)
                        continue;
                    return SpellInabilityReason.NotInDiagonal;
                }
            }
            if (((spellId != 0 && (bool)spellLevelsData.CastTestLos && distanceToTarget > 1)))// || (weaponData != null && weaponData.castTestLos)) && distanceToTarget > 1)
            {
                ArrayList list = Dofus1Line.GetLine(characterPoint.X, characterPoint.Y, targetPoint.X, targetPoint.Y);
                int i = 0;
                while (i < list.Count - 1)
                {
                    Dofus1Line.Point point3 = (Dofus1Line.Point)list[i];
                    MapPoint point4 = new MapPoint((int)Math.Round(Math.Floor(point3.X)), (int)Math.Round(Math.Floor(point3.Y)));
                    isFreeCell = takenCellIds.Find(x => x == point4.CellId) == 0 ? true : false;
                    if (!(isFreeCell))
                        return SpellInabilityReason.LineOfSight;
                    i += 1;
                }
            }

            isFreeCell = takenCellIds.Find(x => x == cellId) == 0 ? true : false;
            if (isFreeCell)
            {
                if ((bool)spellLevelsData.NeedTakenCell)
                    return SpellInabilityReason.NeedTakenCell;
            }
            else if ((bool)spellLevelsData.NeedTakenCell)
                return SpellInabilityReason.NeedFreeCell;
            return SpellInabilityReason.None;
        }
    }
}
