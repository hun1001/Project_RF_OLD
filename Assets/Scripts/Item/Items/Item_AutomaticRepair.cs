using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_AutomaticRepair : Item
    {
        public override void AddItem()
        {
            StartCoroutine(RepairCoroutine());
        }

        private IEnumerator RepairCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                transform.parent.SendMessage("Repair", 0.1f, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
