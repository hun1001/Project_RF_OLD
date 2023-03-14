using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_AutoHealer : Item_AutoHeal
    {

        protected override IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (true)
            {
                yield return waitSeconds;
                _tankDamage.Repair(0.2f);
            }
        }
    }
}
