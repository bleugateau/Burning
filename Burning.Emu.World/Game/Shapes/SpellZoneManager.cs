using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Data.D2P;
using Burning.DofusProtocol.Datacenter;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Game.Fight.Fighters;
using Burning.Emu.World.Game.Shapes.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Shapes
{
    public class SpellZoneManager : SingletonManager<SpellZoneManager>
    {

        public List<Fighter> GetFightersHitFromTargetMask(Fight.Fight fight, List<uint> cells, Fighter caster, uint cellId, EffectInstanceDice effect)
        {
            var fighters = new List<Fighter>();

            foreach (var targetMask in effect.TargetMask)
            {
                switch ((TargetMaskEnum)targetMask)
                {
                    case TargetMaskEnum.a:
                        fighters.AddRange(fight.Fighters.Where(x => x.Life > 0 && x.Team == caster.Team && cells.Contains((uint)x.CellId)));
                        break;
                    case TargetMaskEnum.A:
                        fighters.AddRange(fight.Fighters.Where(x => x.Life > 0 && x.Team != caster.Team && cells.Contains((uint)x.CellId)));
                        break;
                    case TargetMaskEnum.g:
                        fighters.AddRange(fight.Fighters.Where(x => x.Life > 0 && x.Team == caster.Team && x != caster && cells.Contains((uint)x.CellId)));
                        break;
                    case TargetMaskEnum.c:
                        if(cells.Contains((uint)caster.CellId))
                        {
                            fighters.Add(caster);
                        }
                        break;
                    case TargetMaskEnum.C:
                        fighters.Add(caster);
                        break;

                    case TargetMaskEnum.D:
                    case TargetMaskEnum.H:
                    case TargetMaskEnum.J:
                    case TargetMaskEnum.l:
                    case TargetMaskEnum.M:
                    case TargetMaskEnum.m:
                    case TargetMaskEnum.j:
                    case TargetMaskEnum.L:
                    case TargetMaskEnum.P:
                        break;
                    default:
                        break;
                }
            }
            return fighters;
        }

        public IZone getZone(DofusProtocol.Data.D2P.Map map, int pShape, uint pZoneSize, uint pMinZoneSize, int casterCellId, int cellId, bool pIgnoreShapeA = false, uint pStopAtTarget = 0, bool pIsWeapon = false)
        {
            Line l = null;
            Cross shapeT = null;
            Square shapeW = null;
            Cross shapePlus = null;
            Cross shapeSharp = null;
            Cross shapeStar = null;
            Cross shapeMinus = null;
            switch ((SpellShapeEnum)pShape)
            {
                case SpellShapeEnum.X:
                    return new Cross(pMinZoneSize, pIsWeapon || pZoneSize != 0 ? pZoneSize : pMinZoneSize != 0 ? pMinZoneSize : pZoneSize, map);
                case SpellShapeEnum.L:
                    l = new Line(pZoneSize, map);
                    l._nDirection = (uint)new MapPoint(casterCellId).AdvancedOrientationTo(new MapPoint(cellId), false);
                    return l;
                case SpellShapeEnum.l:
                    l = new Line(pZoneSize, map);
                    //casterInfos = FightEntitiesFrame.getCurrentInstance().getEntityInfos(CurrentPlayedFighterManager.getInstance().currentFighterId);
                    l._minRadius = pMinZoneSize;
                    l._nDirection = (uint)new MapPoint(casterCellId).AdvancedOrientationTo(new MapPoint(cellId), false);
                    l._fromCaster = true;
                    l._stopAtTarget = pStopAtTarget == 1 ? true : false;
                    l._casterCellId = (uint)casterCellId;
                    return l;
                case SpellShapeEnum.T:
                    shapeT = new Cross(0, pZoneSize, map);
                    shapeT.onlyPerpendicular = true;
                    return shapeT;
                case SpellShapeEnum.D:
                    return new Cross(0, pZoneSize, map);
                case SpellShapeEnum.C:
                    return new Lozenge(pMinZoneSize, pZoneSize, map);
                case SpellShapeEnum.O:
                    return new Lozenge(pZoneSize, pZoneSize, map);
                case SpellShapeEnum.Q:
                    return new Cross(pMinZoneSize != 0 ? pMinZoneSize : 1, pZoneSize != 0 ? pZoneSize : 1, map);
                case SpellShapeEnum.V:
                    return new Cone(0, pZoneSize, map);
                case SpellShapeEnum.W:
                    shapeW = new Square(0, pZoneSize, map);
                    shapeW._diagonalFree = true;
                    return shapeW;
                case SpellShapeEnum.plus:
                    shapePlus = new Cross(0, pZoneSize != 0 ? pZoneSize : 1, map);
                    shapePlus._diagonal = true;
                    return shapePlus;
                case SpellShapeEnum.sharp:
                    shapeSharp = new Cross(pMinZoneSize, pZoneSize, map);
                    shapeSharp._diagonal = true;
                    return shapeSharp;
                case SpellShapeEnum.slash:
                    return new Line(pZoneSize, map);
                case SpellShapeEnum.star:
                    shapeStar = new Cross(0, pZoneSize, map);
                    shapeStar._allDirections = true;
                    return shapeStar;
                case SpellShapeEnum.minus:
                    shapeMinus = new Cross(0, pZoneSize, map);
                    shapeMinus.onlyPerpendicular = true;
                    shapeMinus._diagonal = true;
                    return shapeMinus;
                case SpellShapeEnum.G:
                    return new Square(0, pZoneSize, map);
                case SpellShapeEnum.I:
                    return new Lozenge(pZoneSize, 63, map);
                case SpellShapeEnum.U:
                    return new HalfLozenge(0, pZoneSize, map);
                case SpellShapeEnum.A:
                case SpellShapeEnum.a:
                    if (!pIgnoreShapeA)
                    {
                        return new Lozenge(0, 63, map);
                    }
                    break;
                case SpellShapeEnum.P:
                default:
                    return new Cross(0, 0, map);
            }
            return new Cross(0, 0, map);
        }
    }
}