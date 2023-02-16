using System;
using System.Collections;
using System.Collections.Generic;
using Scene;
using TMPro;
using UnityEngine;
using Util;

namespace UI
{
    public class CanvasManager : MonoSingleton<CanvasManager>
    {
        [SerializeField]
        private SceneType _currentSceneType = SceneType.None;
        
        private Dictionary<SceneType, SceneCanvases> _sceneCanvases = null;

        private void Awake()
        {
            _sceneCanvases = new();

            foreach (Transform c in transform)
            {
                var s = c.GetComponent<SceneCanvases>();
                if (s != null)
                {
                    _sceneCanvases.Add(s.SceneType, s);
                }
            }
            
            ChangeSceneCanvas(_currentSceneType);
        }
        
        public void ChangeSceneCanvas(SceneType type)
        {
            if (_currentSceneType != SceneType.None)
            {
                _sceneCanvases[_currentSceneType].gameObject.SetActive(false);
            }

            if (_sceneCanvases.ContainsKey(type))
            {
                _currentSceneType = type;
                _sceneCanvases[_currentSceneType].gameObject.SetActive(true);
            }
            else
            {
                Debug.LogError($"SceneType {type} is not registered in CanvasManager");
            }
        }
    }
}
