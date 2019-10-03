using Burning.DofusProtocol.Network.Types;
using Burning.Emu.World.Entity;
using Burning.Emu.World.Network;
using Burning.Emu.World.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Fighters
{
    public class CharacterFighter : Fighter
    {
        public Character Character { get; set; }

        public CharacterFighter(int id, Character character, int cellId)
        {
            this.Id = id;
            this.Character = character;
            this.CellId = cellId;
        }

        public GameFightCharacterInformations GetGameFightCharacterInformations()
        {

            var character = this.Character;

            GameContextActorPositionInformations positionInformations = new GameContextActorPositionInformations(this.Id, new EntityDispositionInformations(this.CellId, 1));
            GameFightMinimalStats gameFightMinimalStats = new GameFightMinimalStats();
            ActorExtendedAlignmentInformations actorExtendedAlignment = new ActorExtendedAlignmentInformations(0, 0, 0, 0, 0, 0, 0, 0);

            return new GameFightCharacterInformations(this.Id, new EntityDispositionInformations(this.CellId, 1), character.Look, new GameContextBasicSpawnInformation(0, true, positionInformations), 0, gameFightMinimalStats, new List<uint>(), character.Name, new PlayerStatus(1), -1, 0, false, (uint)character.Level, actorExtendedAlignment, character.Breed, character.Sex);
        }
    }
}
