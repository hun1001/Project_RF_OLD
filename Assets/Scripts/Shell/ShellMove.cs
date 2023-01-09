using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class ShellMove : MonoBehaviour
    {
        private float _speed = 5f;

        void Update()
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
        }
    }
}
