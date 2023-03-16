using UnityEngine;
using Util;
using Keyword;

namespace Tank
{
    public class Tank_Damage : Base.CustomComponent<Tank>
    {
        private float _currentHealth = 0;
        public float CurrentHealthPercent => _currentHealth / Instance.Hp * 100;

        private float _armour = 0f;

        //TODO : 여기 HP바 관련된것도 수정 필요

        public void Repair(float percent)
        {
            percent *= 0.01f;
            if (_currentHealth + Instance.Hp * percent > Instance.Hp)
            {
                _currentHealth = Instance.Hp;
            }
            else
            {
                _currentHealth += Instance.Hp * percent;
            }
            EventManager.TriggerEvent(EventKeyword.OnTankDamaged + Instance.TankID, -Instance.Hp * (percent * 0.01f));
        }

        private void Awake()
        {
            _currentHealth = Instance.Hp;
            //_armour = Instance.Armour;
        }

        private void OnHit(float damage)
        {
            #region 2번 스킬 테스트
            damage = damage - (damage * 0.01f * _armour);
            #endregion

            EventManager.TriggerEvent(EventKeyword.OnTankDamaged + Instance.TankID, damage);
            _currentHealth -= damage;
        }

        public void SetArmour(float value)
        {
            _armour = value;
            //if(value <= 0f)
            //{
            //    _armour = Instance.Armour;
            //}
        }
    }
}
