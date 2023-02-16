using System;
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

        protected T Instance => _instance ??= GetComponent<T>();
    }
}
