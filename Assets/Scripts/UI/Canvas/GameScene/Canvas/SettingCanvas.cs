using UnityEngine;
using UnityEngine.UI;
using Scene;
using Keyword;

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
            GetComponentInParent<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.PlayGame, CanvasNameKeyword.SettingCanvas);
        }

        private void OpenSettingCanvas()
        {
            if (_isOpen == false)
            {
                if (Time.timeScale == 1f) // 결과창, 아이템창이 안떴을때
                {
                    GetComponentInParent<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Setting, CanvasNameKeyword.PlayInformationCanvas);
                }
            }
            else
            {
                CloseButtonClicked();
            }
        }
    }
}
