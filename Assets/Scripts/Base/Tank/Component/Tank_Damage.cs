using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Damage : TankComponent
    {
        public void TakeDamage(int damage)
        {
            Debug.Log("Take Damage: " + damage);
        }
    }
}
