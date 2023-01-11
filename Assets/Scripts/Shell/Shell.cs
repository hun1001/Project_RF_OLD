using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell : MonoBehaviour
    {
        [SerializeField]
        private SO.ShellSO _shellSO = null;
        public SO.ShellSO ShellSO => _shellSO;

        private float _speed = 1f;
        public float Speed => _speed;

        private float _range = 1f;
        public float Range => _range;

        private void SetSpeed(float speed)
        {
            _speed = speed;
        }

        private void SetRange(float range)
        {
            _range = range;
        }
    }
}
