using System.Collections;
using System.Collections.Generic;
using Scene;
using UnityEngine;

namespace UI
{
    public class SceneCanvases : MonoBehaviour
    {
        [SerializeField]
        private SceneType _sceneType = SceneType.None;
        public SceneType SceneType => _sceneType;
    }
}
