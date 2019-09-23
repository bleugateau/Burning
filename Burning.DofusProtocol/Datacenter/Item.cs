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

        /* 2.50
        public int Id;
        public uint NameId;
        public uint TypeId;
        public uint DescriptionId;
        public int IconId;
        public uint Level;
        public uint RealWeight;
        public bool Cursed;
        public int UseAnimationId;
        public bool Usable;
        public bool Targetable;
        public bool Exchangeable;
        public double Price;
        public bool TwoHanded;
        public bool Etheral;
        public int ItemSetId;
        public string Criteria;
        public string CriteriaTarget;
        public bool HideEffects;
        public bool Enhanceable;
        public bool NonUsableO0other;
        public uint AppearanceId;
        public bool SecretRecipe;
        public List<uint> DropMonsterIds;
        public uint RecipeSlots;
        public List<uint> RecipeIds;
        public bool BonusIsSecret;
        public List<EffectInstance> PossibleEffects;
        public List<uint> FavoriteSubAreas;
        public uint FavoriteSubAreasBonus;
        public int CraftXpRatio;
        public bool NeedUseConfirm;
        public bool IsDestructible;
        public List<List<double>> NuggetsBySubarea;
        public List<uint> ContainerIds;
        public List<List<int>> ResourcesBySubarea;
        public ItemType Type;
        public uint Weight;
        public bool ObjectIsDisplayOnWeb;
        public bool IsSaleable;
        public string CraftVisible;
        public string CraftFeasible;
        public List<int> EvolutiveEffectIds;
        public List<int> DropTemporisMonsterIds;
        public bool NonUsableOnAnother;

    */
    }
}
