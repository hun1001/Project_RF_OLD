using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class CustomComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        private T _instance = null;

        public T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GetComponent<T>();
                }

                return _instance;
            }
        }
    }
}
