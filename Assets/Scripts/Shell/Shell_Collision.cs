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
            switch (TypeReader.GetHitType(Instance.transform.forward.normalized, other.contacts[0].normal))
            {
                case HitType.PENETRATION:
                    PoolManager.Instance.Get("Assets/Prefabs/Effect/WFX_ExplosiveSmoke.prefab", Instance.transform.position);
                    PoolManager.Instance.Pool("Assets/Prefabs/Shell/Shell.prefab", gameObject);
                    other.gameObject.SendMessage("OnHit", 250);
                    break;
                case HitType.RICOCHET:
                    transform.rotation = Quaternion.LookRotation(Vector3Calculator.GetReflectionVector(Instance.transform.forward.normalized, other.contacts[0].normal));
                    break;
            }
        }
    }
}
