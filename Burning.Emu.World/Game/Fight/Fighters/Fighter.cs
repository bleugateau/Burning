﻿using Burning.DofusProtocol.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Burning.Emu.World.Game.Fight.Fighters
{
    public abstract class Fighter
    {
        public int Id { get; set; }

        public int TimelineOrder { get; set; }

        public int Initiative { get; set; }

        public int Life { get; set; }

        public int LifeBase { get; set; }

        public int ShieldPoints { get; set; }

        public int AP { get; set; }

        public int PM { get; set; }

        public int CellId { get; set; }

        public TeamEnum Team { get; set; }

        public Fight Fight
        {
            get
            {
                return FightManager.Instance.Fights.Where(x => x.FightState != FightStateEnum.FIGHT_ENDED && x.Defenders.Find(d => d.Id == this.Id) != null || x.Challengers.Find(c => c.Id == this.Id) != null).Select(f => f).FirstOrDefault();
            }
        }

        public Fighter(TeamEnum team)
        {
            this.Team = team;
        }

        public void OnLifeLost()
        {
            if (this.Fight == null)
                return;

            if(this.Life <= 0)
            {
                //dead sequence
                Console.WriteLine("JOUEUR MORT");
            }

            if ((this.Fight.Defenders.FindAll(x => x.Life > 0).Count == 0) || (this.Fight.Challengers.FindAll(x => x.Life > 0).Count == 0))
            {
                this.Fight.EndFight();
            }
        }
    }
}
