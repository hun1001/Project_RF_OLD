using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class Shell_Collision : ShellComponent
    {
        private void OnCollisionEnter(Collision other)
        {
            // �Ի纤�͸� �˾ƺ���. (�浹�Ҷ� �浹�� ��ü�� �Ի� ���� �븻��)
            Vector3 incomingVector = Instance.transform.forward.normalized;
            incomingVector = incomingVector.normalized;
            // �浹�� ���� ���� ���͸� ���س���.
            Vector3 normalVector = other.contacts[0].normal;
            // ���� ���Ϳ� �Ի纤���� �̿��Ͽ� �ݻ纤�͸� �˾Ƴ���.
            Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector); //�ݻ簢
            reflectVector = reflectVector.normalized;

            transform.rotation = Quaternion.LookRotation(reflectVector);
        }
    }
}
