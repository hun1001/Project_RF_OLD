using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;

namespace Item
{
    public class Item_EmergencyRepair : Item
    {
        private Tank_Damage _tankDamage = null;

        public override void AddItem()
        {
            _tankDamage = transform.parent.GetComponent<Tank_Damage>();
            StartCoroutine(RepairCoroutine());
        }

        private IEnumerator RepairCoroutine()
        {
            while (true)
            {
                transform.parent.SendMessage("Repair", 0.5f, SendMessageOptions.DontRequireReceiver);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
