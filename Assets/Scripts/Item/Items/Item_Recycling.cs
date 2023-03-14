using Keyword;
using UnityEngine;

namespace Item
{
    public class Item_Recycling : Item
    {
        private Tank.Tank_Damage _tankDamage = null;

        public override void AddItem()
        {
            transform.parent.TryGetComponent(out _tankDamage);

            EventManager.StartListening(EventKeyword.OnOpponentDestroyed, () =>
            {
                _tankDamage.Repair(2f);
            });
        }
    }
}
