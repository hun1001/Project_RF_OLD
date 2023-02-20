using System.Collections;
using System.Collections.Generic;
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
               // FindObjectOfType<UI.ControllerCanvas>().GoldText.text = PlayerPrefs.GetInt("Gold").ToString();
                PoolManager.Instance.Pool(this.gameObject);
            }
        }
    }
}
