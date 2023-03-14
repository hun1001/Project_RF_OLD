using Keyword;
using UnityEngine;

namespace Item
{
    public class Item_Recycling : Item
    {
        public override void AddItem()
        {
            EventManager.StartListening(EventKeyword.OnOpponentDestroyed, () =>
            {
                transform.parent.SendMessage("Repair", 2f, SendMessageOptions.DontRequireReceiver);
            });
        }
    }
}
