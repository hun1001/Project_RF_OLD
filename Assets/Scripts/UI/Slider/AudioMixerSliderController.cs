using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace UI
{
    public class AudioMixerSliderController : SliderController
    {
        [SerializeField]
        private AudioMixer _audioMixer = null;

        [SerializeField]
        private string _mixerName = null;

        protected override void Awake()
        {
            base.Awake();
            _slider.value = PlayerPrefs.GetFloat(_mixerName);
            _audioMixer.SetFloat(_mixerName, PlayerPrefs.GetFloat(_mixerName));
        }

        protected override void SliderValueChanged(float value)
        {
            if (value == -40f) value = -80f;
            PlayerPrefs.SetFloat(_mixerName, value);
            _audioMixer.SetFloat(_mixerName, value);
        }
    }
}
