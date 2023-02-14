using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_DamageWithHPBar : Tank_Damage
    {
        private PlayCanvas _playCanvas = null;
        private Bar _hpBar = null;
        private bool _isHit = false;
        public bool IsHit
        {
            get
            {
                return _isHit;
            }
            set
            {
                _isHit = value;
            }
        }

        protected override void Assignment()
        {
            base.Assignment();
            _playCanvas = FindObjectOfType<PlayCanvas>();
            _hpBar = Instance.HealthBar;
            _hpBar.MaxValue = Instance.TankSO.hp;
        }

        protected override void OnHit(float damage)
        {
            base.OnHit(damage);
            _hpBar.Value = _currentHealth;
            _isHit = true;
            if(_hpBar.Value <= 0f && CompareTag("PlayerTank"))
            {
                _playCanvas.ResultPanel.SetActive(true);
            }
        }
    }
}
