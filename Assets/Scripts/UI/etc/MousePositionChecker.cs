using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class MousePositionChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool IsPointerStay { get; private set; }

        private void OnEnable()
        {
            IsPointerStay = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPointerStay = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPointerStay = false;
        }
    }
}
