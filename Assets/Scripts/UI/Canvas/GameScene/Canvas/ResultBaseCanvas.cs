using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scene;

namespace UI
{
    public class ResultBaseCanvas : BaseCanvas
    {

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
