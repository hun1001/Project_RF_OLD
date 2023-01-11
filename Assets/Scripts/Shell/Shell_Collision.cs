using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Shell
{
    public class Shell_Collision : ShellComponent
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(Vector3Calculator.GetIncomingAngle(Instance.transform.forward.normalized, other.contacts[0].normal));
            transform.rotation = Quaternion.LookRotation(Vector3Calculator.GetReflectionVector(Instance.transform.forward.normalized, other.contacts[0].normal));
        }
    }
}
