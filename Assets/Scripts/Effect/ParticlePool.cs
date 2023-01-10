using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class ParticlePool : MonoBehaviour
{
    void OnEnable()
    {
        StartCoroutine("CheckIfAlive");
    }

    IEnumerator CheckIfAlive()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (!GetComponent<ParticleSystem>().IsAlive(true))
            {
                PoolManager.Instance.Pool("Assets/Resource/Effect/WFX_ExplosiveSmoke.prefab", this.gameObject);
            }
        }
    }
}
