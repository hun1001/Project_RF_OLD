using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public float NextFire => _nextFire;
    }
}
