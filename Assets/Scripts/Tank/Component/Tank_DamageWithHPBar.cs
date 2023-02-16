using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_DamageWithHPBar : Tank_Damage
    {
        private ControllerCanvas _controllerCanvas = null;
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

        protected new void Assignment()
        {
            _controllerCanvas = FindObjectOfType<ControllerCanvas>();
            _hpBar.MaxValue = Instance.TankSO.hp;
        }

        protected override void OnHit(float damage)
        {
            base.OnHit(damage);
            _hpBar.Value = _currentHealth;
            _isHit = true;
            if(_hpBar.Value <= 0f && CompareTag("PlayerTank"))
            {
                //_controllerCanvas.ResultPanel.SetActive(true);
            }
        }
    }
}
