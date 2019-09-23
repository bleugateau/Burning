using System;
using System.Collections.Generic;
using System.Text;

namespace Burning.Emu.World.Game.Command
{
    public class CommandAttribute : Attribute
    {
        public string CommandeName { get; set; }

        public int Grade { get; set; }

        public CommandAttribute(string commandeName, int grade = 0)
        {
            this.CommandeName = commandeName;
            this.Grade = grade;
        }
    }
}
