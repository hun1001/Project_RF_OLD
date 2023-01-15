using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Shell
{
    public class Shell_Collision : Base.CustomComponent<Shell>
    {
        private void OnCollisionEnter(Collision other)
        {
            float angle = Vector3Calculator.GetIncomingAngle(Instance.transform.forward.normalized, other.contacts[0].normal);

            Debug.Log(angle);

            switch (TypeReader.GetHitType(angle))
            {
                case HitType.PENETRATION:
                    PoolManager.Instance.Get("Assets/Prefabs/Effect/WFX_ExplosiveSmoke.prefab", Instance.transform.position);
                    PoolManager.Instance.Pool("Assets/Prefabs/Shell/Shell.prefab", gameObject);
                    other.gameObject.SendMessage("OnHit", 250, SendMessageOptions.DontRequireReceiver);
                    break;
                case HitType.RICOCHET:
                    transform.rotation = Quaternion.LookRotation(Vector3Calculator.GetReflectionVector(Instance.transform.forward.normalized, other.contacts[0].normal));
                    break;
            }
        }
    }
}
