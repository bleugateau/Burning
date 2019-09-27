using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.DofusProtocol.Network.Types;
using Burning.DofusProtocol.Enums;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Burning.DofusProtocol.Datacenter;
using Burning.Common.Utility.EntityLook;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using Burning.Emu.World.Entity;
using Burning.DofusProtocol.Network.Messages;
using System.Linq;

namespace Burning.Emu.World.Repository
{
    public class InventoryRepository : SingletonManager<InventoryRepository>, IRepository<Inventory>
    {
        public IMongoCollection<Inventory> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<Inventory>(dataName);

            //lazy loading item
            ItemRepository.Instance.Initialize("items");
        }

        public void Insert(Inventory entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(Inventory entity)
        {
            var updateFields = Builders<Inventory>.Update.Set("ObjectItems", entity.ObjectItems);
            this.Collection.UpdateOne(Builders<Inventory>.Filter.Eq("_id", entity.Id), updateFields);
        }

        public Inventory GetInventoryFromCharacter(Character character)
        {
            return this.Collection.Find(Builders<Inventory>.Filter.Eq("CharacterId", character.Id)).Limit(1).FirstOrDefault();
        }

        public ObjectItem GenerateItemFromId(int id)
        {
            var itemTemplate = ItemRepository.Instance.GetItemDataById(id);

            var item = new ObjectItem();
            item.objectGID = (uint)itemTemplate.id;
            item.objectUID = (uint)GetUniqID(); //generate objectUID
            item.quantity = 1;
            item.position = (uint)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED;

            List<ObjectEffect> effects = new List<ObjectEffect>();

            foreach (var effect in itemTemplate.possibleEffects)
            {
                if (effect is EffectInstanceDice)
                {
                    var cast = (EffectInstanceDice)effect;
                    //177 == apparat coiffe
                    int jet = 0;
                    if (cast.DiceNum == cast.DiceSide || cast.DiceNum > cast.DiceSide)
                        jet = (int)cast.DiceNum;
                    else
                        jet = new Random().Next((int)(cast.DiceNum), (int)(cast.DiceSide + 1));

                    if (itemTemplate.typeId == 177)//apparat hat
                    {
                        if (cast.EffectId == 983)
                            continue;

                        if(cast.EffectId == 1179)
                            jet = cast.Value;
                    }

                    effects.Add(new ObjectEffectInteger(cast.EffectId, (uint)jet));

                }
            }

            item.effects = effects;

            return item;
        }

        public Burning.DofusProtocol.Datacenter.Item GetItemFromUID(Inventory inventory, int uid)
        {
            //piocher le UID dans objectItems de notre clientActiveCharacter
            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);

            if (item == null)
                return null;

            return ItemRepository.Instance.GetItemDataById((int)item.objectGID);
        }

        public bool IsEquipped(Inventory inventory, ObjectItem item)
        {
            if (item.position != (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED)
                return true;

            return false;
        }

        private int GetSameEffectCount(ObjectItem possibleItemStack, ObjectItem item)
        {
            int countSameOfSameEffects = 0;

            for(int i = 0; i < possibleItemStack.effects.Count; i++)
            {
                if(possibleItemStack.effects[i] is ObjectEffectInteger)
                {
                    if(possibleItemStack.effects[i].actionId == item.effects[i].actionId && ((ObjectEffectInteger)possibleItemStack.effects[i]).value == ((ObjectEffectInteger)item.effects[i]).value)
                    {
                        countSameOfSameEffects++;
                    }
                    else
                    {
                        return countSameOfSameEffects;
                    }
                }

            }

            return countSameOfSameEffects;
        }

        public List<ObjectItem> GetStackedItem(Inventory inventory)
        {
            List<ObjectItem> stackedItems = new List<ObjectItem>();

            foreach(var item in inventory.ObjectItems)
            {
                bool isStack = false;
                var possibleStack = stackedItems.Find(x => x.objectGID == item.objectGID && x.position == (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED && x.effects.Count == item.effects.Count);

                if (possibleStack != null)
                {
                    isStack = GetSameEffectCount(possibleStack, item) == possibleStack.effects.Count ? true : false;
                }

                if (isStack && !this.IsEquipped(inventory, item))
                {
                    possibleStack.quantity++;
                }
                else
                {
                    stackedItems.Add(item);
                }
            }

            return stackedItems;
        }

        public bool IsStacked(Inventory inventory, int gid)
        {
            var items = inventory.ObjectItems.FindAll(x => x.objectGID == gid);

            return items.Count > 1 ? true : false;
        }

        public List<ObjectItem> GetStackItemsFromItem(Inventory inventory, ObjectItem item)
        {
            List<ObjectItem> resultStack = new List<ObjectItem>();
            var possibleItems = inventory.ObjectItems.FindAll(x => x.objectGID == item.objectGID && x.objectUID != item.objectUID && x.effects.Count == item.effects.Count);

            foreach(var possibleItem in possibleItems)
            {
                if (possibleItem.effects.Count == this.GetSameEffectCount(possibleItem, item))
                    resultStack.Add(possibleItem);
            }

            return resultStack;
            //return  inventory.ObjectItems.FindAll(x => x.objectGID == item.objectGID && x.objectUID != item.objectUID && x.effects.Count == item.effects.Count);
        }

        public uint GetItemApparatSkinId(ObjectItem item)
        {
            uint skin = 0;
            ObjectEffectInteger effect = (ObjectEffectInteger)item.effects.Find(x => x.actionId == 1176);

            if(effect != null)
            {
                var template = ItemRepository.Instance.GetItemDataById((int)effect.value);
                if (template != null)
                    skin = template.appearanceId;
            }

            return skin;
        }

        public void UnequipItem(WorldClient client, Inventory inventory, int uid, bool dissociate = false) //todo faire pour les objets stack
        {
            //var item = inventory.ObjectItems.Find(x => x.objectUID == uid);
            var look = new Look(client.ActiveCharacter.EntityLook);
            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);

            if (item == null)
                return;

            List<ObjectItem> objectItemsStack = GetStackItemsFromItem(inventory, item);

            item.position = (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED;

            var itemInThisPositionTemplate = this.GetItemFromUID(inventory, (int)item.objectUID);

            if (itemInThisPositionTemplate != null && itemInThisPositionTemplate.appearanceId != 0)
            {
                uint apparatSkin = this.GetItemApparatSkinId(item);
                if (apparatSkin != 0)
                    look.RemoveSkin(apparatSkin);
                //car faut enlever l'ancien aussi
                look.RemoveSkin(itemInThisPositionTemplate.appearanceId);
            }
                

            //objetmovementmessage a 63
            if (objectItemsStack.Count != 0)
            {
                client.SendPacket(new ObjectQuantityMessage(objectItemsStack[0].objectUID, (uint)(objectItemsStack.Count + 1), 0));
                client.SendPacket(new ObjectDeletedMessage(item.objectUID));
            }
            else
            {
                client.SendPacket(new ObjectMovementMessage(item.objectUID, (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED));
            }
            

            this.Update(inventory);

            client.ActiveCharacter.EntityLook = look.GetDatas();
            CharacterRepository.Instance.Update(client.ActiveCharacter);
        }

        public void DissociateApparat(WorldClient client, int uid)
        {
            var inventory = client.ActiveCharacter.Inventory;
            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);

            if (item == null)
                return;

            //remove l'effect
            //remove unequip
            //ajouter apparat dans inventaire
            var apparatEffect = (ObjectEffectInteger)item.effects.Find(x => x.actionId == 1176);

            if (apparatEffect != null)
            {
                var apparatItem = this.GenerateItemFromId((int)apparatEffect.value);
                if (apparatItem != null)
                {
                    this.UnequipItem(client, inventory, (int)item.objectUID); //on désequipe
                    item.effects.Remove(apparatEffect); //on enlever effet apparance

                    //client.SendPacket(new ObjectModifiedMessage(item));

                    List<ObjectItem> objectItemsStacked = this.GetStackItemsFromItem(inventory, item);
                    //en cas de lot d'item on update la quantity d'un item non equipé
                    client.SendPacket(new ObjectDeletedMessage(item.objectUID));
                    if (objectItemsStacked.Count != 0)
                    {
                        client.SendPacket(new ObjectQuantityMessage(objectItemsStacked[0].objectUID, (uint)(objectItemsStacked.Count + 1), 0));
                    }
                    else
                    {
                        client.SendPacket(new ObjectAddedMessage(item, 0));
                    }


                    inventory.ObjectItems.Add(apparatItem); //on se rajoute l'apparart en inventaire


                    List<ObjectItem> objectApparatItemsStacked = this.GetStackItemsFromItem(inventory, apparatItem);
                    //en cas de lot d'item on update la quantity d'un item non equipé
                    if(objectApparatItemsStacked.Count != 0)
                    {
                        client.SendPacket(new ObjectQuantityMessage(objectApparatItemsStacked[0].objectUID, (uint)(objectApparatItemsStacked.Count + 1), 0));
                    }
                    else
                    {
                        client.SendPacket(new ObjectAddedMessage(apparatItem, 0));
                    }
                }
            }
            this.Update(inventory);
        }

        public void AssociateApparat(WorldClient client, Inventory inventory, ObjectItem apparatItem, ObjectItem item)
        {
            //delete l'apparat et ajouter l'effect a l'item TODO
            item.effects.Add(new ObjectEffectInteger(1176, apparatItem.objectGID));
            client.SendPacket(new ObjectDeletedMessage(item.objectUID));
            client.SendPacket(new ObjectAddedMessage(item, 0));

            //delete de l'apparat
            client.SendPacket(new ObjectDeletedMessage(apparatItem.objectUID));
            inventory.ObjectItems.Remove(apparatItem);

            this.Update(inventory);
        }

        public void MoveItemToPosition(WorldClient client, int uid, int position, bool apparat = false)
        {
            var inventory = this.GetInventoryFromCharacter(client.ActiveCharacter);

            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);
            var itemInThisPosition = inventory.ObjectItems.Find(x => x.position == position && x.position != (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED);
            var itemTemplate = this.GetItemFromUID(inventory, uid);
            uint appartSkin = GetItemApparatSkinId(item);

            if (item == null || itemTemplate == null)
                return;

            if (apparat && itemInThisPosition == null) //si object est un apparat et que aucun ancien item on peux pas
                return;

            if (apparat && item.TypeId != itemInThisPosition.TypeId)
                return;

            if (apparat && itemInThisPosition.effects.Find(x => x.actionId == 1176) != null) //si posséde déjà un apparat
                return;
            
            //bool isStackedItem = IsStacked(inventory, (int)item.objectGID); //check stacked item
            List<ObjectItem> stackedItemsList = this.GetStackItemsFromItem(inventory, item);
            var stackedItem = item;

            if (stackedItemsList.Count != 0)
            {
                if (itemInThisPosition != null && stackedItemsList.Find(x => x.objectUID == itemInThisPosition.objectUID) != null) //if is item from same stack
                    return;

                item = stackedItemsList[0];
            }

            //criterion
            if (itemTemplate.level > client.ActiveCharacter.Level)
            {
                client.SendPacket(new ObjectErrorMessage((int)ObjectErrorEnum.LEVEL_TOO_LOW));
                return;
            }

            //si apparat on ajoute un effect
            if (apparat)
            {
                this.AssociateApparat(client, inventory, item, itemInThisPosition);
            }
            else
                item.position = (uint)position;

            if (itemInThisPosition != null) //delete is item ancienemment equipé
            {
                this.UnequipItem(client, inventory, (int)itemInThisPosition.objectUID);
            }

            this.Update(inventory);

            //gérer les stats des items BIENTOT QUAND INVENTAIRE BIEN ENTAMER
            if (itemTemplate.appearanceId != 0 && !apparat)
            {
                var look = new Look(client.ActiveCharacter.EntityLook);

                if (appartSkin != 0)
                    look.AddSkin(appartSkin);
                else
                    look.AddSkin(itemTemplate.appearanceId);

                client.ActiveCharacter.EntityLook = look.GetDatas();

                CharacterRepository.Instance.Update(client.ActiveCharacter);
            }

            if(!apparat)
                client.SendPacket(new ObjectMovementMessage((uint)item.objectUID, (uint)position));

            if(stackedItemsList.Count != 0)
            {
                if(!apparat)
                    client.SendPacket(new ObjectAddedMessage(item, 0));

                client.SendPacket(new SetUpdateMessage((uint)itemTemplate.itemSetId, new List<uint>() { item.objectGID }, new List<ObjectEffect>()));
                client.SendPacket(new ObjectQuantityMessage((uint)uid, (uint)stackedItemsList.Count, 0));
            }
        }

        //id unique pour le UID
        private int GetUniqID()
        {
            var ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            double t = ts.TotalMilliseconds / 1000;

            int a = (int)Math.Floor(t);
            int b = (int)((t - Math.Floor(t)) * 1000000);

            return a + b;
        }
    }
}
