using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Tank
{
    public class Tank_Damage : Base.CustomComponent<Tank>
    {
        protected float _currentHealth = 0;

        protected override void Assignment()
        {
            _currentHealth = Instance.TankSO.hp;
        }

        protected virtual void OnHit(float damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                PoolManager.Instance.Pool(this.gameObject);
            }
        }
    }
}
