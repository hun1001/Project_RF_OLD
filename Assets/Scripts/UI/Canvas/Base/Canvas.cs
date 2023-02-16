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
        public Action OnEnable { get; protected set; }

        private Action _onDisable = null;
        public Action OnDisable { get; protected set; }
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            
            _onEnable += () => _canvas.enabled = true;
            _onDisable += () => _canvas.enabled = false;
        }
    }
}
