using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Burning.Common.Managers.Singleton
{
    public abstract class SingletonManager<T> where T : class
    {
        private static volatile T instance;
        private static object syncRoot = new Object();
        /// <summary>
        ///   Returns the singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                lock (syncRoot)
                {
                    return SingletonAllocator.instance;
                }
            }
            protected set { SingletonAllocator.instance = value; }
        }
        


        #region Nested type: SingletonAllocator

        internal static class SingletonAllocator
        {
            internal static T instance;

            static SingletonAllocator()
            {
                CreateInstance(typeof(T));
            }

            public static T CreateInstance(Type type)
            {
                ConstructorInfo[] ctorsPublic = type.GetConstructors(
                    BindingFlags.Instance | BindingFlags.Public);

                if (ctorsPublic.Length > 0)
                    return instance = (T)Activator.CreateInstance(type);

                ConstructorInfo ctorNonPublic = type.GetConstructors(
                    BindingFlags.Instance | BindingFlags.NonPublic).First();

                if (ctorNonPublic == null)
                {
                    throw new System.Exception(
                        type.FullName +
                        " doesn't have a private/protected constructor so the property cannot be enforced.");
                }

                try
                {
                    return instance = (T)ctorNonPublic.Invoke(new object[0]);
                }
                catch (System.Exception e)
                {
                    throw new System.Exception(
                        "The Singleton couldnt be constructed, check if " + type.FullName + " has a default constructor",
                        e);
                }
            }
        }

        #endregion
    }
}
