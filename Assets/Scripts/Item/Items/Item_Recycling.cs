using Keyword;
using UnityEngine;

namespace Item
{
    public class Item_Recycling : Item
    {
        private Transform _parent = null;

        public override void AddItem()
        {
            _parent = transform.parent;

            EventManager.StartListening(EventKeyword.OnOpponentDestroyed, () =>
            {
                _parent.SendMessage("Repair", 2f, SendMessageOptions.DontRequireReceiver);
            });
        }
    }
}
