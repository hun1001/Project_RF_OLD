using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TechTreeCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _backButton = null;

        [SerializeField]
        private Transform _techTreeTransform = null;

        protected override void SetOnEnableAction()
        {
            gameObject.SendMessage("SetTechTree", _techTreeTransform);
        }

        protected override void SetOnDisableAction()
        {
            gameObject.SendMessage("ResetTechTree");
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
