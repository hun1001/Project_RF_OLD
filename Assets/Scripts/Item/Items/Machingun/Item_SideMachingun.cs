using Util;
using UnityEngine;

namespace Item
{
    public class Item_SideMachingun : Item_Machingun
    {
        private static bool _isFirst = false;

        public override void AddItem()
        {
            base.AddItem();
            Cover(_isFirst);
        }

        private void Cover(bool isFirst)
        {
            if (isFirst == false)
            {
                _isFirst = true;
                transform.localPosition = new Vector3(3f, 2f, 0f);
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);

                PoolManager.Instance.Get<Item>("SideMachineGun", GameObject.Find("Player").transform.GetChild(0)).AddItem();
            }
            else
            {
                transform.localPosition = new Vector3(-3f, 2f, 0f);
                transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
            }
        }
    }
}
