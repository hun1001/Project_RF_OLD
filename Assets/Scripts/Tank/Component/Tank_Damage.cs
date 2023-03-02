using UnityEngine;
using Util;
using Keyword;

namespace Tank
{
    public class Tank_Damage : Base.CustomComponent<Tank>
    {
        private float _currentHealth = 0;

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
            #region 2번 스킬 테스트
            Skill_Test2 _skill = GetComponent<Skill_Test2>();
            if (_skill != null)
            {
                damage = damage - ((damage / 100f) * _skill.CurrentArmour);
            }
            #endregion

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
