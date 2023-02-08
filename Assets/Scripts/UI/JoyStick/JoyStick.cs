using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class JoyStick : MonoBehaviour, IDragHandler,  IBeginDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        protected RectTransform _rectTransform = null;
        protected RectTransform _rectTransformChild = null;

        private Action _onPointerDown = null;
        protected Action _onPointerUp = null;

        private Vector2 _direction = Vector2.zero;
        private Vector2 _joyStickOriginPosition = Vector2.zero;

        private float _radius = 0.0f;
        protected float _dragTime = 0.0f;
        
        private bool _isTouching = false;
        private bool _isDragging = false;

        protected virtual void Awake()
        {
            _rectTransform = transform.GetChild(0).GetComponent<RectTransform>();
            _rectTransformChild = _rectTransform.GetChild(0).GetComponent<RectTransform>();
            _radius = _rectTransform.rect.width * 0.5f;
            _joyStickOriginPosition = _rectTransform.anchoredPosition;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _rectTransform.position = eventData.position;
            _rectTransformChild.position = eventData.position;
            _isTouching = true;
            _onPointerDown?.Invoke();
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 pos = (eventData.position - (Vector2)_rectTransform.position) / (_radius/10);
            pos = Vector2.ClampMagnitude(pos, _radius);
            _rectTransformChild.localPosition = pos;
            
            _direction = pos;
            if (_dragTime < 3f) _dragTime += Time.deltaTime;
        }
        
        public virtual void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _isTouching = false;
            _rectTransformChild.localPosition = Vector2.zero;
            _rectTransform.anchoredPosition = _joyStickOriginPosition;
            _direction = Vector2.zero;
            _dragTime = 0.0f;
            _onPointerUp?.Invoke();
        }

        public Vector2 Direction => _direction.normalized;
        public float Scalar => _direction.magnitude/_radius;
        public float Vertical => _direction.normalized.y;
        public float Horizontal => _direction.normalized.x;
        public bool IsDragging => _isDragging;
        public bool IsTouching => _isTouching;
        public float DragTime => _dragTime;

        public void AddOnPointerDownListener(Action action)
        {
            _onPointerDown += action;
        }

        public void AddOnPointerUpListener(Action action)
        {
            _onPointerUp += action;
        }
    }
}