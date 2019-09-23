using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Command
{
    public class CommandData
    {
        public object Instance;
        public string CommandeName;
        public ConstructorInfo Methode;

        public CommandData(object instance, string commande, ConstructorInfo method)
        {
            this.Instance = instance;
            this.CommandeName = commande;
            this.Methode = method;
        }
    }
}
