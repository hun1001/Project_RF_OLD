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

        private void SetValue()
        {
            _barImage.fillAmount = _value / _maxValue;
        }

    }
}
