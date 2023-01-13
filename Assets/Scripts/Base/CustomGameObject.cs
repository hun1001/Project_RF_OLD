using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class CustomGameObject : MonoBehaviour
    {
        private bool _isInitialized = false;
        public bool IsInitialized => _isInitialized;

        public virtual void Initialize()
        {
            _isInitialized = true;
        }
    }
}
