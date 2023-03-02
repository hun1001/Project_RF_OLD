using UnityEngine;
using Util;
using Keyword;

namespace Tank
{
    public class Tank_Damage : Base.CustomComponent<Tank>
    {
        private float _currentHealth = 0;
        public float CurrentHealthPercent => _currentHealth / Instance.Hp * 100;

        //TODO : 여기 HP바 관련된것도 수정 필요

        public void Repair(float percent)
        {
            if (_currentHealth + Instance.Hp * (percent / 100) > Instance.Hp)
            {
                _currentHealth = Instance.Hp;
            }
            else
            {
                _currentHealth += Instance.Hp * (percent / 100);
                EventManager.TriggerEvent(EventKeyword.OnTankDamaged + Instance.TankID, -Instance.Hp * (percent / 100));
            }
        }

        private void Awake()
        {
            _currentHealth = Instance.Hp;
        }

        private void OnHit(float damage)
        {
            EventManager.TriggerEvent(EventKeyword.OnTankDamaged + Instance.TankID, damage);
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                if (CompareTag("PlayerTank") == false)
                {
                    PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 2);
                    PlayerPrefs.SetInt("Destroy", PlayerPrefs.GetInt("Destroy") + 1);
                    EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
                }

                EventManager.TriggerEvent(EventKeyword.OnTankDestroyed + Instance.TankID);
                PoolManager.Instance.Pool(this.gameObject);
            }
        }
    }
}
