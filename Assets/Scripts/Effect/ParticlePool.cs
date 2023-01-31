using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Effect
{
    public class ParticlePool : MonoBehaviour
    {
        private ParticleSystem _particleSystem = null;

        void OnEnable()
        {
            _particleSystem ??= GetComponent<ParticleSystem>();
            _particleSystem.Play();
            StartCoroutine("CheckIfAlive");
        }

        IEnumerator CheckIfAlive()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if (!GetComponent<ParticleSystem>().IsAlive(true))
                {
                    PoolManager.Instance.Pool("Assets/Prefabs/Effect/WFX_ExplosiveSmoke.prefab", this.gameObject);
                    yield break;
                }
            }
        }
    }
}