using System.Collections;
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

        private Vector2 _pos = Vector2.zero;
        private Vector2 _direction = Vector2.zero;
        private Vector2 _joyStickOriginPosition = Vector2.zero;

        private Transform _camera = null;
        private Vector3 _heading = Vector3.zero;
        private Vector2 _headingDir = Vector2.zero;
        private Vector3 _vector3Dir = Vector3.zero;

        private float _radius = 0.0f;
        private float _dragTime = 0.0f;

        private bool _isTouching = false;
        private bool _isDragging = false;

        protected virtual void Awake()
        {
            _radius = _rectTransform.rect.width * 0.5f;
            _joyStickOriginPosition = _rectTransform.anchoredPosition;
            _camera = Camera.main.transform;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownAction();

            _rectTransform.position = eventData.position;
            _rectTransformChild.position = eventData.position;
            _isTouching = true;

            StartCoroutine(nameof(CheckTime));
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isDragging = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _pos = (eventData.position - (Vector2)_rectTransform.position) / (_radius / 10f);
            _rectTransformChild.localPosition = Vector2.ClampMagnitude(_pos, _radius);

            _heading = _camera.localRotation * Vector3.forward;
            _vector3Dir = _heading * -_pos.x;
            _vector3Dir += Quaternion.Euler(0, -90, 0) * _heading * _pos.y;

            _headingDir.x = _vector3Dir.z;
            _headingDir.y = _vector3Dir.x;

            _direction = _headingDir;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpAction();

            StopCoroutine(nameof(CheckTime));

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
        public float Scalar => _direction.magnitude / _radius;
        public float Vertical => _direction.normalized.y;
        public float Horizontal => _direction.normalized.x;
        public bool IsDragging => _isDragging;
        public bool IsTouching => _isTouching;
        public float DragTime => _dragTime;

        private IEnumerator CheckTime()
        {
            while (true)
            {
                _dragTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}
