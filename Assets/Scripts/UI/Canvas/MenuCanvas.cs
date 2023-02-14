using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace UI
{
    public class MenuCanvas : UI.Canvas
    {
        [SerializeField]
        private Button _startButton = null;
        [SerializeField]
        private Button _exitButton = null;

        private void Awake()
        {
            _startButton.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene("MapTesting"));
            _exitButton.onClick.AddListener(() =>
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            });
        }
    }
}
