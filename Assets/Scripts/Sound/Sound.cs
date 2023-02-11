using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Util;

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
        
        public void Play(AudioClip audioClip, AudioMixerGroup mixer, float volume = 1f, float pitch = 1f)
        {
            _audioSource.clip = audioClip;
            _audioSource.outputAudioMixerGroup = mixer;
            _audioSource.loop = false;
            _audioSource.volume = volume;
            _audioSource.pitch = pitch;
            _audioSource.Play();
            StartCoroutine(PoolSoundCoroutine());
        }

        public void LoopPlay(AudioClip audioClip, AudioMixerGroup mixer, float volume = 0.5f, float pitch = 1f)
        {
            _audioSource.clip = audioClip;
            _audioSource.outputAudioMixerGroup = mixer;
            _audioSource.loop = true;
            _audioSource.volume = volume;
            _audioSource.pitch = pitch;
            _audioSource.Play();
        }

        public void VolumeSetting(float volume)
        {
            _audioSource.volume = volume;
        }

        public void PitchSetting(float pitch)
        {
            _audioSource.pitch = pitch;
        }
        
        private IEnumerator PoolSoundCoroutine()
        {
            yield return new WaitForSeconds(_audioSource.clip.length);
            PoolManager.Instance.Pool("Assets/Prefabs/Sound/Sound.prefab", this.gameObject);
        }

        public float Volume => _audioSource.volume;
        public float Pitch => _audioSource.pitch;
    }
}
