using UnityEngine;
using Scene;
using UnityEngine.UI;

namespace UI
{
    public class ResultBaseCanvas : BaseCanvas
    {
        [Header("Button")]
        [SerializeField]
        private Button _mainButton = null;

        [SerializeField]
        private Button _restartButton = null;

        [Header("Text")]
        [SerializeField]
        private TextController _lifeTimeSecondText;

        [SerializeField]
        private TextController _destroyText;

        protected override void Awake()
        {
            base.Awake();
            _mainButton.onClick.AddListener(MainButtonClicked);
            _restartButton.onClick.AddListener(RestartButtonClicked);
        }

        protected override void SetOnEnableAction()
        {
            Time.timeScale = 0f;
            _lifeTimeSecondText.SetText(string.Format("{0:0.0} sec", Time.timeSinceLevelLoad));
            _destroyText.SetText(PlayerPrefs.GetInt("Destroy").ToString());
        }

        protected override void SetOnDisableAction()
        {
            Time.timeScale = 1f;
        }

        private void MainButtonClicked()
        {
            Time.timeScale = 1f;
            SceneLoadManager.Instance.LoadScene(SceneType.MenuScene);
        }

        private void RestartButtonClicked()
        {
            Time.timeScale = 1f;
            SceneLoadManager.Instance.LoadScene(SceneType.GameScene);
        }
    }
}
