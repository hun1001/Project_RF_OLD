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

        private bool _isOpen = false;

        protected override void Awake()
        {
            base.Awake();
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _closeButton.onClick.AddListener(CloseButtonClicked);
        }

        private void OnGUI()
        {
            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape)
            {
                OpenSettingCanvas();
            }
        }
        protected override void SetOnEnableAction()
        {
            Time.timeScale = 0f;
            _isOpen = true;
        }

        protected override void SetOnDisableAction()
        {
            Time.timeScale = 1f;
            _isOpen = false;
        }

        private void ExitButtonClicked()
        {
            Time.timeScale = 1f;
            SceneLoadManager.Instance.LoadScene(SceneType.MenuScene);
        }

        private void CloseButtonClicked()
        {
            Time.timeScale = 1f;
        }

        private void OpenSettingCanvas()
        {
            if (_isOpen == false)
            {
                if (true) // 결과창, 아이템창이 안떴을때
                {
                    // var temp = CanvasManager.Instance.GetSceneCanvases(1);
                    // var temp2 = temp as GameSceneCanvases;
                    // temp2?.ChangeCanvas(3);
                }
            }
            else
            {
                CloseButtonClicked();
            }
        }
    }
}
