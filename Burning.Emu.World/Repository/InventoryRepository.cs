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
                    if (cast.DiceNum == cast.DiceSide || cast.DiceNum > cast.DiceSide)
                        effects.Add(new ObjectEffectInteger(cast.EffectId, cast.DiceNum));
                    else
                        effects.Add(new ObjectEffectInteger(cast.EffectId, (uint)new Random().Next((int)(cast.DiceNum), (int)(cast.DiceSide + 1))));
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


        public void UnequipItem(WorldClient client, Inventory inventory, int uid)
        {
            //var item = inventory.ObjectItems.Find(x => x.objectUID == uid);
            var look = new Look(client.ActiveCharacter.EntityLook);
            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);

            if (item == null)
                return;

            item.position = (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED;

            var itemInThisPositionTemplate = this.GetItemFromUID(inventory, (int)item.objectUID);

            if (itemInThisPositionTemplate != null && itemInThisPositionTemplate.appearanceId != 0)
                look.RemoveSkin(itemInThisPositionTemplate.appearanceId);

            //objetmovementmessage a 63
            client.SendPacket(new ObjectMovementMessage(item.objectUID, (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED));

            this.Update(inventory);

            client.ActiveCharacter.EntityLook = look.GetDatas();
            CharacterRepository.Instance.Update(client.ActiveCharacter);
        }

        public void MoveItemToPosition(WorldClient client, int uid, int position)
        {
            var inventory = this.GetInventoryFromCharacter(client.ActiveCharacter);

            var item = inventory.ObjectItems.Find(x => x.objectUID == uid);
            var itemInThisPosition = inventory.ObjectItems.Find(x => x.position == position && x.position != (int)CharacterInventoryPositionEnum.INVENTORY_POSITION_NOT_EQUIPED);
            var itemTemplate = this.GetItemFromUID(inventory, uid);

            if (item == null || itemTemplate == null)
                return;

            if (itemTemplate.level > client.ActiveCharacter.Level)
            {
                client.SendPacket(new ObjectErrorMessage((int)ObjectErrorEnum.LEVEL_TOO_LOW));
                return;
            }

            item.position = (uint)position;
            if (itemInThisPosition != null) //delete is item ancienemment equipé
            {
                this.UnequipItem(client, inventory, (int)itemInThisPosition.objectUID);
            }

            this.Update(inventory);

            //remove ancien skin OK :)
            //déplacer item de l'inventaire enlever ancien OK :)
            //gérer les stats des items BIENTOT QUAND INVENTAIRE BIEN ENTAMER
            if (itemTemplate.appearanceId != 0)
            {
                var look = new Look(client.ActiveCharacter.EntityLook);
                look.AddSkin(itemTemplate.appearanceId);

                client.ActiveCharacter.EntityLook = look.GetDatas();

                CharacterRepository.Instance.Update(client.ActiveCharacter);
            }

            client.SendPacket(new ObjectMovementMessage((uint)uid, (uint)position));
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
