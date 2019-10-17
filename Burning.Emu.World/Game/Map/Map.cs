using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Burning.Common.Entity;
using Burning.Common.Enums;
using Burning.Common.Network;
using Burning.Common.Repository;
using Burning.Emu.World.Network;
using Burning.DofusProtocol.Network.Messages;
using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Repository;
using Burning.Common.Utility.EntityLook;
using Burning.Emu.World.Game.Monster;
using Burning.Emu.World.Game.Fight.Positions;
using Burning.Emu.World.Game.PathFinder;
using Burning.Emu.World.Entity;

namespace Burning.Emu.World.Game.Map
{
    public class Map
    {
        public int Id { get; set; }

        public List<NpcSpawn> NpcSpawnList { get; set; }

        public List<InteractiveElement> InteractiveElementList { get; set; }

        public List<StatedElement> StatedElementList { get; set; }

        public List<MonsterGroup> MonstersGroups { get; set; }

        public Pathfinder Pathfinder { get; set; }

        public Burning.DofusProtocol.Data.D2P.Map MapData { get; set; }

        public FightStartingPositions FightStartingPosition { get; private set; }

        private List<Fight.Fight> Fights { get; set; }

        private List<WorldClient> ClientsOnMap { get; set; }

        private int MonsterGroupsLimit { get; set; }

        private readonly object locker = new object();

        public Map(int mapId, Burning.DofusProtocol.Data.D2P.Map mapData, int monsterGroupsLimit = 3)
        {
            this.Id = mapId;
            this.MapData = mapData;
            this.Pathfinder = new Pathfinder(new int[] { });
            this.Pathfinder.SetMap(this.MapData, true);
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(mapId);
            this.MonsterGroupsLimit = monsterGroupsLimit;
            this.MonstersGroups = FillMonstersGroups();
            this.FightStartingPosition = FightPositionsManager.Instance.BuildFromSchema(this);
            //startfightposition a faire
            this.Fights = new List<Fight.Fight>();
            this.ClientsOnMap = new List<WorldClient>();
            this.InteractiveElementList = new List<InteractiveElement>(); //a fill avec la db
            this.StatedElementList = new List<StatedElement>(); //a fill avec la db
        }

        public List<MonsterGroup> FillMonstersGroups()
        {
            List<MonsterGroup> groupMonsters = new List<MonsterGroup>();
            int actualMonsterGroupSize = this.MonstersGroups != null ? this.MonstersGroups.Count : 0;

            for(int i = actualMonsterGroupSize; i < this.MonsterGroupsLimit; i++)
            {

                var group = new MonsterGroup(this);
                if(group.Monsters.Count != 0)
                    groupMonsters.Add(group);
            }

            return groupMonsters;
        }

        public List<GameRolePlayActorInformations> GetGameRolePlayActorInformations(WorldClient client)
        {
            List<GameRolePlayActorInformations> gameRolePlayActorInformations = new List<GameRolePlayActorInformations>();
            foreach (var otherCharacter in this.ClientsOnMap.FindAll(x => x.ActiveCharacter != null && x.ActiveCharacter.MapId == client.ActiveCharacter.MapId))
            {
                gameRolePlayActorInformations.Add(otherCharacter.ActiveCharacter.GetGameRolePlayCharacterInformations());
                otherCharacter.SendPacket(new GameRolePlayShowActorMessage(client.ActiveCharacter.GetGameRolePlayCharacterInformations()));
            }

            gameRolePlayActorInformations.Add(client.ActiveCharacter.GetGameRolePlayCharacterInformations());

            return gameRolePlayActorInformations;
        }

        public void SendGameMapMovementMessage(List<uint> keyMovements, WorldClient client)
        {
            foreach (var otherClients in this.ClientsOnMap.FindAll(x => x.ActiveCharacter.Id != client.ActiveCharacter.Id))
            {
                otherClients.SendPacket(new GameMapMovementMessage(keyMovements, 2, client.ActiveCharacter.Id));
            }
        }

        public WorldClient GetClientFromCharacter(Character character)
        {
            lock(locker)
            {
                return this.ClientsOnMap.Find(x => x.ActiveCharacter.Id == character.Id);
            }
        }

        public void EnterMap(WorldClient client)
        {
            lock (locker)
            {
                this.ClientsOnMap.Add(client);
                //send update to other
            }
        }

        public void ExitMap(WorldClient client)
        {
            lock (locker)
            {
                var clients = this.ClientsOnMap.FindAll(x => x != client);

                if (this.ClientsOnMap.Contains(client))
                    this.ClientsOnMap.Remove(client);

                foreach (var otherClients in clients)
                {
                    otherClients.SendPacket(new GameContextRemoveElementMessage(client.ActiveCharacter.Id));
                }
            }
        }

        public void RemoveMonsterGroup(WorldClient client, MonsterGroup group)
        {
            lock (locker)
            {
                this.MonstersGroups.Remove(group);

                foreach (var otherClients in this.ClientsOnMap.FindAll(x => x.ActiveCharacter.Id != client.ActiveCharacter.Id))
                {
                    otherClients.SendPacket(new GameContextRemoveElementMessage(group.Id));
                    otherClients.SendPacket(new GameContextRemoveElementMessage(client.ActiveCharacter.Id));
                }
            }
        }

        public Fight.Fight GetFight(int fightId)
        {
            return this.Fights.Find(x => x.Id == fightId);
        }

        public void AddFight(WorldClient client, Fight.Fight fight)
        {
            lock(locker)
            {
                this.Fights.Add(fight);

                foreach (var otherClient in this.ClientsOnMap.FindAll(x => x.ActiveCharacter.Id != client.ActiveCharacter.Id))
                {
                    //??
                    otherClient.SendPacket(new GameFightOptionStateUpdateMessage((uint)fight.Id, 0, 0, true));
                    otherClient.SendPacket(new GameFightOptionStateUpdateMessage((uint)fight.Id, 1, 0, true));
                    otherClient.SendPacket(new GameFightOptionStateUpdateMessage((uint)fight.Id, 0, 1, true));

                    otherClient.SendPacket(new GameRolePlayShowChallengeMessage(fight.GetFightCommonInformations()));
                    otherClient.SendPacket(new MapFightCountMessage((uint)this.Fights.Count));
                }
            }
        }

        public List<FightCommonInformations> GetFightInformationsOnMap()
        {
            List<FightCommonInformations> fightCommons = new List<FightCommonInformations>();

            foreach (var fight in this.Fights.Where(x => x.FightState == Fight.FightStateEnum.FIGHT_CHOICE_PLACEMENT))
            {
                fightCommons.Add(fight.GetFightCommonInformations());
            }

            return fightCommons;
        }

        public void RemoveFightInformationsOnMap(int fightId)
        {
            foreach(var client in this.ClientsOnMap)
            {
                client.SendPacket(new GameRolePlayRemoveChallengeMessage((uint)fightId));
            }
        }

        public void RemoveFight(Fight.Fight fight)
        {
            lock (locker)
            {
                this.Fights.Remove(fight);

                foreach(var client in this.ClientsOnMap)
                {
                    client.SendPacket(new MapFightCountMessage((uint)this.Fights.Count));
                }
            }
        }

        public void ReloadNpc()
        {
            this.NpcSpawnList = NpcSpawnRepository.Instance.GetNpcSpawnsFromMapId(this.Id, false);
            Console.WriteLine("Npc from MapId {0} reloaded.", this.Id);
        }

        public void ReloadMobs()
        {
            Console.WriteLine("Mobs from MapId {0} reloaded.", this.Id);
        }
    }
}
