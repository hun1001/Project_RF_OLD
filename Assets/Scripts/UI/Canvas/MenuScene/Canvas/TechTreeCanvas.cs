using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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

            // 애니메이션 추가 예정

            _backButton.onClick.AddListener(() =>
            {
                FindObjectOfType<MenuSceneCanvases>().ChangeCanvas("MenuCanvas");
            });
        }
    }
}
