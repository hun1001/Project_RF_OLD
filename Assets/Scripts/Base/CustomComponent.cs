using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public abstract class CustomComponent<T> : MonoBehaviour where T : CustomGameObject
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

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => Instance.IsInitialized);
            Assignment();
        }

        protected virtual void Assignment()
        {

        }
    }
}
