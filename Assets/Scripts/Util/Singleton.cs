using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Util
{
    public class Singleton<T> where T : new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
