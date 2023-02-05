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
        
        public void Play(AudioClip audioClip, AudioMixerGroup mixer)
        {
            _audioSource.clip = audioClip;
            _audioSource.outputAudioMixerGroup = mixer;
            _audioSource.loop = false;
            _audioSource.Play();
            StartCoroutine(PoolSoundCoroutine());
        }

        public void LoopPlay(AudioClip audioClip, AudioMixerGroup mixer, float volume = 1f)
        {
            _audioSource.clip = audioClip;
            _audioSource.outputAudioMixerGroup = mixer;
            _audioSource.loop = true;
            _audioSource.volume = volume;
            _audioSource.Play();
        }
        
        private IEnumerator PoolSoundCoroutine()
        {
            yield return new WaitForSeconds(_audioSource.clip.length);
            PoolManager.Instance.Pool("Assets/Prefabs/Sound/Sound.prefab", this.gameObject);
        }
    }
}
