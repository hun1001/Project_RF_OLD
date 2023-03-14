using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_AutoHeal : Item
    {
        protected Transform _parent;

        public override void AddItem()
        {
            _parent = transform.parent;

            StartCoroutine(RepairCoroutine());
        }

        protected virtual IEnumerator RepairCoroutine()
        {
            WaitForSeconds waitSeconds = new WaitForSeconds(1f);
            while (true)
            {
                yield return waitSeconds;
                _parent.SendMessage("Repair", 0.1f, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
