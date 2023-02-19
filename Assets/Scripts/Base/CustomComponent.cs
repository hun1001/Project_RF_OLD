using System;
using System.Collections;
using System.Collections.Generic;
//using Codice.CM.SEIDInfo;
using UnityEngine;

namespace Base
{
    public abstract class CustomComponent<T> : MonoBehaviour where T : CustomGameObject<T>
    {
        private T _instance = null;

        protected T Instance => _instance ??= GetComponent<T>();
    }
}
