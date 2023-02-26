using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class SliderController : MonoBehaviour
    {
        protected Slider _slider = null;

        protected virtual void Awake()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(SliderValueChanged);
        }

        protected abstract void SliderValueChanged(float value);
    }
}
