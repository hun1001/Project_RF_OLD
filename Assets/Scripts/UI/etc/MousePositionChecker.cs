using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class MousePositionChecker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public bool IsPointerStay { get; private set; }
        
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
