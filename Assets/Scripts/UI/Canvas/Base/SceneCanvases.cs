using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Scene;
using UnityEngine;

namespace UI
{
    public abstract class SceneCanvases : MonoBehaviour
    {
        [SerializeField]
        private SceneType _sceneType = SceneType.None;
        public SceneType SceneType => _sceneType;
        
        private Dictionary<string, UI.Canvas> _canvases = null;

        public Action OnEnable;
        public Action OnDisable;
        
        private void Awake()
        {
            _canvases = new();
            
            foreach (Transform c in transform)
            {
                var canvas = c.GetComponent<UI.Canvas>();
                if (canvas != null)
                {
                    _canvases.Add(canvas.CanvasName, canvas);
                }
            }
        }
        
        public void SetOnEnableAction()
        {
            
        }
        
        public void SetOnDisableAction()
        {
            
        }
    }
}
