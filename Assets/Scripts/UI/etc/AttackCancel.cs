using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class AttackCancel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private bool _isCancelAttack = false;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isCancelAttack = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            CancelAttackReset();
        }

        public void CancelAttackReset()
        {
            _isCancelAttack = false;
        }

        public bool IsCancelAttack => _isCancelAttack;
    }
}
