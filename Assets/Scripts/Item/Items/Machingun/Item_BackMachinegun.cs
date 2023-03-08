using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item
{
    public class Item_BackMachinegun : Item_Machingun
    {
        public override void AddItem()
        {
            base.AddItem();
            transform.localPosition = new Vector3(0f, 2f, -4f);
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
