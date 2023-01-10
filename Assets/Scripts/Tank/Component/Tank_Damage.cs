using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Damage : TankComponent
    {
        private float _currentHealth = 0;

        private void Awake()
        {
            _currentHealth = Instance.TankSO.hp;
        }

        public void OnHit(float damage)
        {
            _currentHealth -= damage;
            Debug.Log("Current HP: " + _currentHealth);

            if (_currentHealth <= 0)
            {
                Debug.Log("Dead");
            }
        }
    }
}
