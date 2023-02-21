using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scene;

namespace UI
{
    public class MenuBaseCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _startButton = null;
        
        [SerializeField]
        private Button _exitButton = null;

        protected override void SetOnEnableAction()
        {
            
        }
        
        protected override void SetOnDisableAction()
        {
            
        }

        protected override void Awake()
        {
            base.Awake();
            _startButton.onClick.AddListener(() =>
            {
                CanvasManager.Instance.ChangeSceneCanvas(SceneType.GameScene);
                SceneLoadManager.Instance.LoadScene(SceneType.GameScene);
            });
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
