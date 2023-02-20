using UnityEngine;
using Util;
using Keyword;

namespace Tank
{
    public class Tank_Damage : Base.CustomComponent<Tank>
    {
        private float _currentHealth = 0;

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
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1);
                EventManager.TriggerEvent(EventKeyword.OnTankDestroyed + Instance.TankID);
                // TODO: 여기 지금 이대로면 플레이어 죽어도 1원 추가됨
                EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
                PoolManager.Instance.Pool(this.gameObject);
            }
        }
    }
}
