using Burning.DofusProtocol.Enums;
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

        public int Agility { get; set; }

        public int Strength { get; set; }

        public int Wisdom { get; set; }

        public int Water { get; set; }

        public int Intelligence { get; set; }

        public int AllDamageBonus { get; set; }

        public int AgilityDamageBonus { get; set; }

        public int StrengthDamageBonus { get; set; }

        public int WaterDamageBonus { get; set; }

        public int IntelligenceDamageBonus { get; set; }

        public int AgilityResistance { get; set; }

        public int StrengthResistance { get; set; }

        public int NeutralResistance { get; set; }

        public int WaterResistance { get; set; }

        public int IntelligenceResistance { get; set; }

        public int AgilityPercentResistance { get; set; }

        public int StrengthPercentResistance { get; set; }

        public int NeutralPercentResistance { get; set; }

        public int WaterPercentResistance { get; set; }

        public int IntelligencePercentResistance { get; set; }

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

            this.Agility = 0;
            this.Water = 0;
            this.Intelligence = 0;
            this.Strength = 0;
            this.Wisdom = 0;

            this.AllDamageBonus = 0;
            this.WaterDamageBonus = 0;
            this.AgilityDamageBonus = 0;
            this.IntelligenceDamageBonus = 0;
            this.StrengthDamageBonus = 0;

            this.AgilityResistance = 0;
            this.WaterResistance = 0;
            this.StrengthResistance = 0;
            this.IntelligenceResistance = 0;
            this.NeutralResistance = 0;
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
