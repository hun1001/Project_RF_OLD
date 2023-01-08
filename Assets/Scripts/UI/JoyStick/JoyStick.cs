using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class JoyStick : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        protected RectTransform _rectTransform = null;
        protected RectTransform _rectTransformChild = null;
        
        private Vector2 _direction = Vector2.zero;
        
        private float _radius = 0.0f;

        protected virtual void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransformChild = transform.GetChild(0).GetComponent<RectTransform>();
            _radius = _rectTransform.rect.width * 0.5f;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _rectTransformChild.position = eventData.position;
        }
        
        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = eventData.position - (Vector2)_rectTransform.position;
            pos = Vector2.ClampMagnitude(pos, _radius);
            _rectTransformChild.localPosition = pos;
            
            _direction = pos.normalized;
        }

        public virtual void OnEndDrag(PointerEventData eventData)
        {
            _rectTransformChild.localPosition = Vector2.zero;
            _direction = Vector2.zero;
        }

        public Vector2 Direction => _direction;
        public  float Vertical => _direction.y;
        public float Horizontal => _direction.x;
    }
}