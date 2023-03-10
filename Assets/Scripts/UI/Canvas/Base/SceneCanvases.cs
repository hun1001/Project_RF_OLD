using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class SceneCanvases : MonoBehaviour
    {
        private Dictionary<string, UI.BaseCanvas> _canvases = null;
        public Dictionary<string, UI.BaseCanvas> Canvases => _canvases;

        private void Awake()
        {
            _canvases = new();

            foreach (Transform c in transform)
            {
                var canvas = c.GetComponent<UI.BaseCanvas>();
                if (canvas != null)
                {
                    _canvases.Add(canvas.CanvasName, canvas);
                }
            }
        }

        public virtual void ChangeCanvas(string name)
        {
            foreach (var c in _canvases)
            {
                if (c.Key == name)
                    c.Value.OnEnableAction?.Invoke();
                else
                    c.Value.OnDisableAction?.Invoke();
            }
        }
    }
}
