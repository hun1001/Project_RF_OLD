using UnityEngine;

namespace Item
{
    public class Item_Healkit : Item
    {
        public override void AddItem()
        {
            EventManager.StartListening(Keyword.EventKeyword.OnStageClear, () =>
            {
                transform.parent.SendMessage("Repair", 5f, SendMessageOptions.DontRequireReceiver);
            });
        }
    }
}
