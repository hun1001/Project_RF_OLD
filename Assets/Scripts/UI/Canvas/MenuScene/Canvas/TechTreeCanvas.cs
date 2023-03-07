using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TechTreeCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _backButton = null;

        protected override void SetOnEnableAction()
        {

        }

        protected override void SetOnDisableAction()
        {

        }

        protected override void Awake()
        {
            base.Awake();
            _backButton.onClick.AddListener(() =>
            {
                FindObjectOfType<MenuSceneCanvases>().ChangeCanvas("MenuCanvas");
            });
        }
    }
}
