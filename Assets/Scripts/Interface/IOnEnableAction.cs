using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface IOnEnableAction
    {
        public Action OnEnable { get; protected set; }
        void SetOnEnableAction();
    }
}
