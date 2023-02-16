using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class Canvas : MonoBehaviour
    {
        private Canvas _canvas = null;
        
        private Action _onEnable = null;
        public Action OnEnable => _onEnable;

        private Action _onDisable = null;
        public Action OnDisable => _onDisable;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            
            _onEnable += () => _canvas.enabled = true;
            _onEnable += SetOnEnableAction;
            
            _onDisable += () => _canvas.enabled = false;
            _onDisable += SetOnDisableAction;
        }
        
        protected abstract void SetOnEnableAction();
        protected abstract void SetOnDisableAction();
    }
}
