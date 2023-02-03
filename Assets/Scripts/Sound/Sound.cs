using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound
{
    [RequireComponent(typeof(AudioSource))]
    public class Sound : MonoBehaviour
    {
        private AudioSource _audioSource = null;
        
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void Play(AudioClip audioClip, AudioMixerGroup mixer)
        {
            _audioSource.clip = audioClip;
            _audioSource.outputAudioMixerGroup = mixer;
            _audioSource.Play();
        }
    }
}
