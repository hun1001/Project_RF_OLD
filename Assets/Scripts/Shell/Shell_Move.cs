using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell_Move : ShellComponent
    {
        private void Update()
        {
            transform.Translate(Vector3.forward * Instance.Speed * Time.deltaTime);
        }
    }
}
