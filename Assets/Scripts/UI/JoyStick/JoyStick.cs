using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Keyword;

namespace UI
{
    public class JoyStick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private RectTransform _rectTransform = null;
        [SerializeField]
        private RectTransform _rectTransformChild = null;

        private Vector2 _direction = Vector2.zero;
        private Vector2 _joyStickOriginPosition = Vector2.zero;

        private float _radius = 0.0f;
        private float _dragTime = 0.0f;
        
        private bool _isTouching = false;
        private bool _isDragging = false;

        protected virtual void Awake()
        {
            _radius = _rectTransform.rect.width * 0.5f;
            _joyStickOriginPosition = _rectTransform.anchoredPosition;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownAction();
            
            _rectTransform.position = eventData.position;
            _rectTransformChild.position = eventData.position;
            _isTouching = true;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = (eventData.position - (Vector2)_rectTransform.position) / (_radius/15);
            pos = Vector2.ClampMagnitude(pos, _radius);
            _rectTransformChild.localPosition = pos;
            
            _direction = pos;
            if (_dragTime < 3f) _dragTime += Time.deltaTime;
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpAction();
            
            _isTouching = false;
            _rectTransformChild.localPosition = Vector2.zero;
            _rectTransform.anchoredPosition = _joyStickOriginPosition;
            _direction = Vector2.zero;
            _dragTime = 0.0f;
        }
        
        protected virtual void OnPointerDownAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnPointerDownMoveJoyStick);
        }
        
        protected virtual void OnPointerUpAction()
        {
            EventManager.TriggerEvent(EventKeyword.OnPointerDownMoveJoyStick);
        }

        public Vector2 Direction => _direction.normalized;
        public float Scalar => _direction.magnitude/_radius;
        public float Vertical => _direction.normalized.y;
        public float Horizontal => _direction.normalized.x;
        public bool IsDragging => _isDragging;
        public bool IsTouching => _isTouching;
        public float DragTime => _dragTime;
    }
}