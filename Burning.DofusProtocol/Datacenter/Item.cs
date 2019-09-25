using Burning.DofusProtocol.Data.D2o;
using System.Collections.Generic;

namespace Burning.DofusProtocol.Datacenter
{
    [D2oClass("Items", true)]
    public class Item : IDataObject
    {
        public const string MODULE = "Items";
        public const uint EQUIPEMENTCATEGORY = 0;
        public const uint CONSUMABLESCATEGORY = 1;
        public const uint RESSOURCESCATEGORY = 2;
        public const uint QUESTCATEGORY = 3;
        public const uint OTHERCATEGORY = 4;
        public const int MAXJOBLEVELGAP = 100;


        public int id;

        public uint nameId;

        public uint typeId;

        public uint descriptionId;

        public uint iconId;

        public uint level;

        public uint realWeight;

        public bool cursed;

        public int useAnimationId;

        public bool usable;

        public bool targetable;

        public bool exchangeable;

        public int price;

        public bool twoHanded;

        public bool etheral;

        public int itemSetId;

        public string criteria;

        public string criteriaTarget;

        public bool hideEffects;

        public bool enhanceable;

        public bool nonUsableOnAnother;

        public uint appearanceId;

        public bool secretRecipe;

        public List<uint> dropMonsterIds;

        public List<uint> dropTemporisMonsterIds;

        public uint recipeSlots;

        public List<uint> recipeIds;

        public bool objectIsDisplayOnWeb;

        public bool bonusIsSecret;

        public List<EffectInstance> possibleEffects;

        public List<uint> evolutiveEffectIds;

        public List<uint> favoriteSubAreas;

        public uint favoriteSubAreasBonus;

        public int craftXpRatio;

        public string craftVisible;

        public string craftFeasible;

        public bool needUseConfirm;

        public bool isDestructible;

        public bool isSaleable;

        public List<List<int>> nuggetsBySubarea;

        public List<uint> containerIds;

        public List<List<int>> resourcesBySubarea;
    }
}
