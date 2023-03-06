using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_AutoHeal : Item
    {
        public override void AddItem()
        {
            StartCoroutine(RepairCoroutine());
        }

        protected virtual IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (true)
            {
                yield return waitSeconds;
                transform.parent.SendMessage("Repair", 0.1f, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
