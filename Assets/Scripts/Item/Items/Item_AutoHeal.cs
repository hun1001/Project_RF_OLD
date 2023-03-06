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
            while (true)
            {
                yield return new WaitForSeconds(1f);
                transform.parent.SendMessage("Repair", 0.1f, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
