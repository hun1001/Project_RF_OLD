using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scene;

namespace UI
{
    public class ResultCanvas : Canvas
    {

        protected override void SetOnEnableAction()
        {
            
        }
        
        protected override void SetOnDisableAction()
        {
            
        }

        private void MainButtonClicked()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneLoadManager.Instance.LoadScene("MenuScene");
        }

        private void RestartButtonClicked()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            SceneLoadManager.Instance.LoadScene("GameScene");
        }
    }
}
