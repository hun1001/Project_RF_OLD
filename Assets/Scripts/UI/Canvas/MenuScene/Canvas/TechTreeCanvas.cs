using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Keyword;

namespace UI
{
    public class TechTreeCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _backButton = null;

        [SerializeField]
        private Transform _techTreeTransform = null;

        [SerializeField]
        private Transform _techTreeToggleTransform = null;


        protected override void SetOnEnableAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnSetTechTree, _techTreeTransform, 0);
            _techTreeToggleTransform.GetChild(0).GetComponent<Toggle>().isOn = true;
            MoveTechTreePanel(30f);
        }

        protected override void SetOnDisableAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnResetTechTree);
            MoveTechTreePanel(-360f);
        }

        protected override void Awake()
        {
            base.Awake();

            EventManager.TriggerEvent(EventKeyword.OnSetTechTreeToggle, _techTreeToggleTransform, _techTreeTransform);

            OnDisableAction?.Invoke();

            _backButton.onClick.AddListener(() =>
            {
                FindObjectOfType<MenuSceneCanvases>().ChangeCanvas("MenuCanvas");
            });
        }

        private void MoveTechTreePanel(float moveY, float duration = 0.5f)
        {
            _techTreeTransform.DOLocalMoveY(moveY, duration);
        }
    }
}
