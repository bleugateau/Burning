using Burning.Common.Entity;
using Burning.Common.Managers.Singleton;
using Burning.Common.Repository;
using Burning.Emu.World.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Level
{
    public class LevelManager : SingletonManager<LevelManager>
    {

        public LevelExperience GetActualLevelExperience<T>(T context)
        {
            LevelExperience levelExperience = null;

            switch (context)
            {
                case Character character:
                        levelExperience = LevelExperienceRepository.Instance.CharacterLevels.FirstOrDefault(x => x.Level == character.Level);
                    break;
                case Entity.Guild guild:
                        levelExperience = LevelExperienceRepository.Instance.GuildLevels.FirstOrDefault(x => x.Level == guild.Level);
                    break;
            }

            return levelExperience;
        }

        public LevelExperience GetNextLevelByExperience<T>(T context)
        {
            LevelExperience levelExperience = null;

            switch(context)
            {
                case Character character:
                    levelExperience = LevelExperienceRepository.Instance.CharacterLevels.FirstOrDefault(x => x.Level > character.Level);

                    if(levelExperience == null)
                        levelExperience = LevelExperienceRepository.Instance.CharacterLevels.FirstOrDefault(x => x.Level == character.Level);
                    break;
                case Entity.Guild guild:
                    levelExperience = LevelExperienceRepository.Instance.GuildLevels.FirstOrDefault(x => x.Level > guild.Level);

                    if (levelExperience == null)
                        levelExperience = LevelExperienceRepository.Instance.GuildLevels.FirstOrDefault(x => x.Level == guild.Level);
                    break;
            }

            return levelExperience;
        }

        public bool CheckLevelUpFromExperience<T>(T context)
        {
            bool result = false;

            switch (context)
            {
                case Character character:
                    result = LevelExperienceRepository.Instance.CharacterLevels.FirstOrDefault(x => x.Level > character.Level && character.Experience > x.Experience) != null ? true : false;
                    break;
                case Entity.Guild guild:
                    result = LevelExperienceRepository.Instance.GuildLevels.FirstOrDefault(x => x.Level > guild.Level && guild.Experience > x.Experience) != null ? true : false;
                    break;
            }

            return result;
        }
    }
}
