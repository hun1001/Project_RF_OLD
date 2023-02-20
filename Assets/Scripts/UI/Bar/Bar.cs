using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Bar : MonoBehaviour
    {
        private float _maxValue = 0;
        public float MaxValue
        {
            // TODO: 여기 Setter 나중에 상황 봐서 수정 필요해보임
            set
            {
                _maxValue = _maxValue == 0 ? value : _maxValue; 
                _value = _value == 0 ? value : _value;
            }
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
