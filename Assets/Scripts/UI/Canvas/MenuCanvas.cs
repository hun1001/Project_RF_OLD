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

        private void Awake()
        {
            PoolManager.Instance.Clear();
            _startButton.onClick.AddListener(() => SceneLoadManager.Instance.LoadScene("GameScene"));
        }
    }
}
