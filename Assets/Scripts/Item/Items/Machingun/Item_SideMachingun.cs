using Util;
using UnityEngine;

namespace Item
{
    public class Item_SideMachingun : Item_Machingun
    {
        private static int sideMachinegun = 1;

        public override void AddItem()
        {
            base.AddItem();
            Cover(sideMachinegun);
        }

        private void Cover(int i)
        {
            if (sideMachinegun % 2 == 1)
            {
                transform.localPosition = new Vector3(3f, 2f, 0f);
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);

                PoolManager.Instance.Get<Item>("SideMachineGun", GameObject.Find("Player").transform.GetChild(0)).AddItem();
            }
            else
            {
                transform.localPosition = new Vector3(-3f, 2f, 0f);
                transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            }
            sideMachinegun++;
        }
    }
}
