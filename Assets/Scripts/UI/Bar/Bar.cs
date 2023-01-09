using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        private float _maxValue;
        private float _value;

        private Image _barImage = null;

        private void Awake()
        {
            _barImage = GetComponentInChildren<Image>();
        }

        private void SetValue(float value)
        {
            _value = value;
            _barImage.fillAmount = _value / _maxValue;
        }

    }
}
