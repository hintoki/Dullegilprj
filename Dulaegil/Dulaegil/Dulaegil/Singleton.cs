using System;
using System.Collections.Generic;
using System.Text;

namespace Dulaegil
{
    public class Singleton<T> where T : class, new()
    {
        private static object _syncobj = new object();
        private static volatile T _instance = null;

        public static T inst
        {
            get
            {
                if(_instance == null)
                {
                    lock (_syncobj)
                    {
                        _instance = new T();
                    }
                }

                return _instance;
            }
        }
    }
}
