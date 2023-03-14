using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_AutoHeal : Item
    {
        protected Tank.Tank_Damage _tankDamage;

        public override void AddItem()
        {
            transform.parent.TryGetComponent(out _tankDamage);

            StartCoroutine(RepairCoroutine());
        }

        protected virtual IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (true)
            {
                yield return waitSeconds;
                _tankDamage.Repair(0.1f);
            }
        }
    }
}
