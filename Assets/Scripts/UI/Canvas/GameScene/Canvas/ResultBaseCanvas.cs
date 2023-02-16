using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scene;
using UnityEngine.UI;

namespace UI
{
    public class ResultBaseCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _mainButton = null;
        
        [SerializeField]
        private Button _restartButton = null;

        private void Start()
        {
            _mainButton.onClick.AddListener(MainButtonClicked);
            _restartButton.onClick.AddListener(RestartButtonClicked);
        }

        protected override void SetOnEnableAction()
        {
            Time.timeScale = 0f;
        }
        
        protected override void SetOnDisableAction()
        {
            Time.timeScale = 1f;
        }

        private void MainButtonClicked()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneLoadManager.Instance.LoadScene(SceneType.MenuScene);
        }

        private void RestartButtonClicked()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneLoadManager.Instance.LoadScene(SceneType.GameScene);
        }
    }
}
