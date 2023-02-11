using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;

namespace UI
{

    public class TextEffect : MonoBehaviour
    {
        private Transform _cameraTransform;
        private TMPro.TMP_Text _text;

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
            _text = GetComponentInChildren<TMPro.TMP_Text>();
        }

        void LateUpdate()
        {
            transform.LookAt(transform.position + _cameraTransform.rotation * Vector3.forward, _cameraTransform.rotation * Vector3.up);
        }

        public void SetTextEffect(string text, Color color, float size = 1, float duration = 1f)
        {
            _text.text = text;
            _text.color = color;
            _text.fontSize = size;
            Invoke(nameof(Pooling), duration);
        }

        private void Pooling()
        {
            PoolManager.Instance.Pool("Assets/Prefabs/UI/TextEffect.prefab", this.gameObject);
        }
    }
}