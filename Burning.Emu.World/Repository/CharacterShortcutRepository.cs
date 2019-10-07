using Burning.Common.Managers.Database;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.DofusProtocol.Enums;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Repository
{
    public class CharacterShortcutRepository : SingletonManager<CharacterShortcutRepository>, IRepository<CharacterShortcut>
    {
        public IMongoCollection<CharacterShortcut> Collection { get; set; }

        public void Initialize(string dataName)
        {
            this.Collection = DatabaseManager.Instance.World.GetCollection<CharacterShortcut>(dataName);
        }

        public List<CharacterShortcut> GetShortcutByCharacterId(int characterId)
        {
            return this.Collection.Find(Builders<CharacterShortcut>.Filter.Eq("CharacterId", characterId)).Limit(2).ToList();
        }

        public void Insert(CharacterShortcut entity)
        {
            this.Collection.InsertOne(entity);
        }

        public void Update(CharacterShortcut entity)
        {
            var updateFields = Builders<CharacterShortcut>.Update.Set("ShortcutObjects", entity.ShortcutObjects);

            this.Collection.UpdateOne(Builders<CharacterShortcut>.Filter.Eq(x => x.Id, entity.Id), updateFields);
        }

        public void AddShortcutObject(CharacterShortcut shortcutBar, Shortcut shortcutObject)
        {
            if (shortcutBar == null)
                return;

            if (shortcutBar.ShortcutObjects != null)
            {
                var slotAlreadyTaken = shortcutBar.ShortcutObjects.Find(x => x.slot == shortcutObject.slot);
                if (slotAlreadyTaken != null)
                    shortcutBar.ShortcutObjects.Remove(slotAlreadyTaken);
            }

            shortcutBar.ShortcutObjects.Add(shortcutObject);

            this.Update(shortcutBar);
        }

        public void RemoveShortcut(CharacterShortcut shortcutBar, int slot)
        {
            if (shortcutBar == null)
                return;

            var shortcutObject = shortcutBar.ShortcutObjects.Find(x => x.slot == slot);
            if (shortcutObject != null)
            {
                shortcutBar.ShortcutObjects.Remove(shortcutObject);
                this.Update(shortcutBar);
            }
        }
    }
}
