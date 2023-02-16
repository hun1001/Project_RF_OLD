using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using Scene;
using UnityEngine;

namespace UI
{
    public abstract class SceneCanvases : MonoActiveEventBehaviour
    {
        [SerializeField]
        private SceneType _sceneType = SceneType.None;
        public SceneType SceneType => _sceneType;
        
        private Dictionary<string, UI.BaseCanvas> _canvases = null;

        private void Awake()
        {
            _canvases = new();
            OnEnableAction += SetOnEnableAction;
            OnDisableAction += SetOnDisableAction;
            
            foreach (Transform c in transform)
            {
                var canvas = c.GetComponent<UI.BaseCanvas>();
                if (canvas != null)
                {
                    _canvases.Add(canvas.CanvasName, canvas);
                }
            }
        }

        protected abstract void SetOnEnableAction();
        protected abstract void SetOnDisableAction();
    }
}
