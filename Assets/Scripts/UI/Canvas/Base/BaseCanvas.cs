using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

namespace UI
{
    public abstract class BaseCanvas : MonoActiveEventBehaviour
    {
        public string CanvasName => gameObject.name;
        
        private Canvas _canvas = null;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            
            OnEnableAction += SetOnEnableAction;
            OnDisableAction += SetOnDisableAction;
        }
        
        protected abstract void SetOnEnableAction();
        protected abstract void SetOnDisableAction();
    }
}
