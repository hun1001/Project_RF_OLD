using System.Collections;
using System.Collections.Generic;
using Codice.CM.SEIDInfo;
using UnityEngine;

namespace Base
{
    [RequireComponent(typeof(Base.CustomGameObject))]
    public abstract class CustomComponent<T> : MonoBehaviour where T : CustomGameObject
    {
        private T _instance = null;

        protected T Instance
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
