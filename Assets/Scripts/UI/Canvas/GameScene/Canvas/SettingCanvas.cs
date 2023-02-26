using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Scene;

namespace UI
{
    public class SettingCanvas : BaseCanvas
    {
        [Header("Button")]
        [SerializeField]
        private Button _exitButton = null;

        [SerializeField]
        private Button _closeButton = null;

        protected override void Awake()
        {
            base.Awake();
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _closeButton.onClick.AddListener(CloseButtonClicked);
        }

        protected override void SetOnEnableAction()
        {
            Time.timeScale = 0f;
        }

        protected override void SetOnDisableAction()
        {
            Time.timeScale = 1f;
        }

        private void ExitButtonClicked()
        {
            Time.timeScale = 1f;
            CanvasManager.Instance.ChangeSceneCanvas(SceneType.MenuScene);
            SceneLoadManager.Instance.LoadScene(SceneType.MenuScene);
        }

        private void CloseButtonClicked()
        {

        }
    }
}
