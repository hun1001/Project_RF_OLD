using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Turret
{
    public class TurretAI_Attack : Turret_Attack
    {
        protected override void Start()
        {
            // Null
        }

        protected override void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }
        }

        public override void Fire()
        {
            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;

            PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position, _firePoint.rotation);
        }

        public float NextFire => _nextFire;
    }
}
