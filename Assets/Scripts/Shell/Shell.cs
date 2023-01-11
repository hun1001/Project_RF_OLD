using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell : MonoBehaviour
    {
        private float _speed = 1f;

        public float Speed => _speed;

        private void SetSpeed(float speed)
        {
            _speed = speed;
        }
    }
}
