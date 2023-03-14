using UnityEngine;

namespace Item
{
    public class Item_Healkit : Item
    {
        private Transform _parent = null;

        public override void AddItem()
        {
            _parent = transform.parent;

            EventManager.StartListening(Keyword.EventKeyword.OnStageClear, () =>
            {
                _parent.SendMessage("Repair", 5f, SendMessageOptions.DontRequireReceiver);
            });
        }
    }
}
