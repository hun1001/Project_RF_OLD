using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell_Move : ShellComponent
    {
        private float _speed = 1f;

        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}
