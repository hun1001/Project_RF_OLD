using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_DamageWithHPBar : Tank_Damage
    {
        private Bar _hpBar = null;

        protected override void Awake()
        {
            _hpBar = Instance.HealthBar;
            base.Awake();
        }

        private void Start()
        {
            _hpBar.MaxValue = Instance.TankSO.hp;
        }

        public override void OnHit(float damage)
        {
            base.OnHit(damage);
            _hpBar.Value = _currentHealth;
        }
    }
}
