using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class MonoActiveEventBehaviour : MonoBehaviour
    {
        public Action OnEnableAction { get; protected set; }
        public Action OnDisableAction { get; protected set; }
    }
}
