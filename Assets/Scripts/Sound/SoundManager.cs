using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Util;

namespace Sound
{
    public class SoundManager : MonoSingleton<SoundManager>
    {
        [SerializeField]
        private AudioMixer _audioMixer = null;
        
        public void PlaySound(AudioClip audioClip, SoundType soundType)
        {
            var audioSource = PoolManager.Instance.Get<Sound>("a");
            audioSource.Play(audioClip, _audioMixer.outputAudioMixerGroup);
        }
    }
}
