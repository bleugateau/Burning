using Burning.Common.Managers.Singleton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Fight
{
    public class FightManager : SingletonManager<FightManager>
    {
        public List<Fight> Fights { get; set; }

        public void Initialize()
        {
            this.Fights = new List<Fight>();
        }
    }
}
