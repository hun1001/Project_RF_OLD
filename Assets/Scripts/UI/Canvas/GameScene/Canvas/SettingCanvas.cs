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

        private bool _isOpen = false;

        protected override void Awake()
        {
            base.Awake();
            _exitButton.onClick.AddListener(ExitButtonClicked);
            _closeButton.onClick.AddListener(CloseButtonClicked);
        }

        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape)) Test();
        //}

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
            CanvasManager.Instance.ChangeSceneCanvas(SceneType.MenuScene);
            SceneLoadManager.Instance.LoadScene(SceneType.MenuScene);
        }

        private void CloseButtonClicked()
        {
            Time.timeScale = 1f;
            var temp = CanvasManager.Instance.GetSceneCanvases(1);
            var temp2 = temp as GameSceneCanvases;
            temp2?.ChangeCanvas(0);
        }

        //private void Test()
        //{
        //    if(_isOpen == false)
        //    {
        //        if (true) // 결과창, 아이템창이 안떴을때
        //        {
        //            var temp = CanvasManager.Instance.GetSceneCanvases(1);
        //            var temp2 = temp as GameSceneCanvases;
        //            temp2?.ChangeCanvas(3);
        //        }
        //    }
        //    else
        //    {
        //        CloseButtonClicked();
        //    }
        //}
    }
}
