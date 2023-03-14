using Keyword;

namespace Item
{
    public class Item_Adrenaline : Item
    {
        private int _firstHpPercent = 0;
        private Tank.Tank_Damage _tankDamage = null;

        public override void AddItem()
        {
            _tankDamage = transform.parent.GetComponent<Tank.Tank_Damage>();
            _firstHpPercent = 100;

            EventManager.StartListening(EventKeyword.OnTankDamaged + transform.parent.GetComponent<Tank.Tank>().TankID, () =>
            {
                int percentDiff = (int)(_firstHpPercent - _tankDamage.CurrentHealthPercent);
                if (percentDiff > 0)
                {
                    _tankDamage.GetComponent<Tank.Tank>().UpgradeAllStat(percentDiff * 0.1f);
                }
            });
        }
    }
}
