using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        private float _maxValue = 0;
        public float MaxValue
        {
            set => _maxValue = _value = _maxValue == 0 ? value : _maxValue;
        }

        private float _value;
        public float Value
        {
            get => _value;
            
            set
            {
                _value = value;
                _gaugeImage.fillAmount = _value / _maxValue;
            }
        }

        [SerializeField]
        private Image _gaugeImage = null;
    }
}
