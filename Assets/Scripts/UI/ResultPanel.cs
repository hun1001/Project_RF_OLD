using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace UI
{
    public class ResultPanel : MonoBehaviour
    {
        private PlayCanvas _playCanvas = null;

        private void Awake()
        {
            _playCanvas = FindObjectOfType<PlayCanvas>();

            _playCanvas.MainButton.onClick.AddListener(MainButtonClicked);
            _playCanvas.RestartButton.onClick.AddListener(RestartButtonClicked);
        }

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
