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
        public Dictionary<string, UI.BaseCanvas> Canvases => _canvases;

        private void Awake()
        {
            _canvases = new();
            
            OnEnableAction += ()=> gameObject.SetActive(true);
            OnDisableAction += ()=> gameObject.SetActive(false);
            
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
        
        public void ChangeCanvas(string name)
        {
            foreach (var c in _canvases)
            {
                c.Value.gameObject.SetActive(c.Key == name);
            }
        }

        protected abstract void SetOnEnableAction();
        protected abstract void SetOnDisableAction();
    }
}
