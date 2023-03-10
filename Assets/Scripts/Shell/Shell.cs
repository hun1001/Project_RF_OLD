using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell : Base.CustomGameObject<Shell>
    {
        [Header("Data")]
        [SerializeField]
        private SO.ShellSO _shellSO = null;
        public SO.ShellSO ShellSO => _shellSO;

        [Header("Sound")]
        [SerializeField]
        private AudioClip _ricochetSound = null;
        public AudioClip RicochetSound => _ricochetSound;

        [SerializeField]
        private AudioClip _mapRicochetSound = null;
        public AudioClip MapRicochetSound => _mapRicochetSound;

        private float _speed = 1f;
        public float Speed => _speed;

        private float _range = 1f;
        public float Range => _range;

        private void SetSpeed(float speed)
        {
            TryGetComponent<TrailRenderer>(out var trail);
            trail?.Clear();
            _speed = speed;
        }

        private void SetRange(float range)
        {
            _range = range;
        }
    }
}
