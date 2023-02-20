using System;
using UnityEngine;

namespace Base
{
    public abstract class MonoActiveEventBehaviour : MonoBehaviour
    {
        public Action OnEnableAction { get; protected set; }
        public Action OnDisableAction { get; protected set; }
    }
}
