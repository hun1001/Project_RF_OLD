using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_DamageWithHPBar : Tank_Damage
    {
        private Bar _hpBar = null;

        protected override void Assignment()
        {
            base.Assignment();
            _hpBar = Instance.HealthBar;
            _hpBar.MaxValue = Instance.TankSO.hp;
        }

        protected override void OnHit(float damage)
        {
            base.OnHit(damage);
            _hpBar.Value = _currentHealth;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPaused = false;
#else
            Application.Quit();
#endif
        }
    }
}
