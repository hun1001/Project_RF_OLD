using UnityEngine;
using UnityEngine.EventSystems;
using Keyword;
using UnityEngine.UI;

namespace UI
{
    public class JoyStick_ClickActive : JoyStick
    {
        [SerializeField]
        private Image _attackButtonImage = null;

        [SerializeField]
        private GameObject _attackJoyStick = null;
        
        [SerializeField]
        private MousePositionChecker _attackCancelZone = null;

        protected override void OnPointerDownAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnPointerDownAttackJoyStick);
            
            _attackJoyStick.SetActive(true);
            _attackCancelZone.gameObject.SetActive(true);
            _attackButtonImage.enabled = false;
        }
        
        protected override void OnPointerUpAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnPointerUpAttackJoyStick);

            if (_attackCancelZone.IsPointerStay == false)
            {
                EventManager.TriggerEvent(EventKeyword.OnMainBatteryFire);
            }

            _attackJoyStick.SetActive(false);
            _attackCancelZone.gameObject.SetActive(false);
            _attackButtonImage.enabled = true;
        }
    }
}
