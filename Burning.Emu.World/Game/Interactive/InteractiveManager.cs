using Burning.Common.Managers.Singleton;
using Burning.Emu.World.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Emu.World.Game.Interactive
{
    public class InteractiveManager : SingletonManager<InteractiveManager>
    {
        private Dictionary<int, SkillData> skillsList = new Dictionary<int, SkillData>();

        public void Initialize()
        {
            Assembly assembly = typeof(Skill).Assembly;
            foreach (var type in assembly.GetTypes().SelectMany(x => x.GetConstructors()).Where(m => m.GetCustomAttributes(typeof(SkillAttribute), false).Length > 0).ToArray())
            {
                SkillAttribute attr = (SkillAttribute)type.GetCustomAttributes(typeof(SkillAttribute), true)[0];
                Type stringType = Type.GetType(type.DeclaringType.FullName + ", " + assembly.GetName());

                List<Type> paramTypes = new List<Type>();
                List<object> objectParam = new List<object>();

                foreach (var param in type.GetParameters())
                {
                    paramTypes.Add(param.ParameterType);
                    objectParam.Add(null);
                    //Console.WriteLine(param.Name);
                }

                ConstructorInfo ctor = stringType.GetConstructor(paramTypes.ToArray());
                object instance = ctor.Invoke(objectParam.ToArray());

                this.skillsList.Add(attr.SkillId, new SkillData(instance, attr.SkillId, type));
            }

            Console.WriteLine("{0} map interactive skill(s) initialized.", this.skillsList.Count);
        }

        public void Dispatch(int skillId, WorldClient client)
        {
            SkillData skillData = null;
            this.skillsList.TryGetValue(skillId, out skillData);

            if (skillData != null)
            {
                skillData.Constructor.Invoke(skillData.Instance, new object[] { skillId, client });
                skillData.Constructor.DeclaringType.GetMethod("Execute").Invoke(skillData.Instance, null);
            }
        }

    }
}
