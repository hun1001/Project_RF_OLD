using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class JoyStick_ClickActive : JoyStick
    {
        private Image _attackButtonImage = null;

        private GameObject _attackJoyStick = null;
        private GameObject _attackCancelObject = null;

        protected override void Awake()
        {
            base.Awake();
            _attackButtonImage = GetComponent<Image>();
            _rectTransform = _rectTransform.GetChild(0).GetComponent<RectTransform>();
            _rectTransformChild = _rectTransform.GetChild(0).GetComponent<RectTransform>();
            _attackJoyStick = _rectTransform.gameObject;
            _joyStickOriginPosition = _rectTransform.position;
            _attackCancelObject = transform.GetChild(1).gameObject;
            
        }

        private void Start()
        {
            _attackJoyStick.SetActive(false);
            _attackCancelObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            _attackJoyStick.SetActive(true);
            _attackCancelObject.SetActive(true);
            _attackButtonImage.enabled = false;

            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            _attackJoyStick.SetActive(false);
            _attackCancelObject.SetActive(false);
            _attackButtonImage.enabled = true;

            _onPointerUp?.Invoke();
        }
    }
}
