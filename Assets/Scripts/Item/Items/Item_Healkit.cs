using UnityEngine;

namespace Item
{
    public class Item_Healkit : Item
    {
        private Tank.Tank_Damage _tankDamage = null;

        public override void AddItem()
        {
            transform.parent.TryGetComponent(out _tankDamage);

            EventManager.StartListening(Keyword.EventKeyword.OnStageClear, () =>
            {
                _tankDamage.Repair(5f);
            });
        }
    }
}
