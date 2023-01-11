using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell_Collision : ShellComponent
    {
        private void OnCollisionEnter(Collision other)
        {
            // 입사벡터를 알아본다. (충돌할때 충돌한 물체의 입사 벡터 노말값)
            Vector3 incomingVector = Instance.transform.forward.normalized;
            incomingVector = incomingVector.normalized;
            // 충돌한 면의 법선 벡터를 구해낸다.
            Vector3 normalVector = other.contacts[0].normal;
            // 법선 벡터와 입사벡터을 이용하여 반사벡터를 알아낸다.
            Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector); //반사각
            reflectVector = reflectVector.normalized;

            transform.rotation = Quaternion.LookRotation(reflectVector);
        }
    }
}
