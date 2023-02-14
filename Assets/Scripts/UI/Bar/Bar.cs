using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        private float _maxValue;
        public float MaxValue
        {
            set
            {
                _maxValue = value;
            }
        }

        private float _value;
        public float Value
        {
            get
            {
                return _value;
            }
            
            set
            {
                _value = value;
                _barImage.fillAmount = _value / _maxValue;
            }
        }

        protected Image _barImage = null;

        protected virtual void Awake()
        {
            _barImage = transform.GetChild(0).GetComponent<Image>();
        }
    }
}
