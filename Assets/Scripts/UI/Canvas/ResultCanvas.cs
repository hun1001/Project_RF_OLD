using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scene;

namespace UI
{
    public class ResultCanvas : MonoBehaviour
    {

        private void OnEnable()
        {
            Time.timeScale = 0f;
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
