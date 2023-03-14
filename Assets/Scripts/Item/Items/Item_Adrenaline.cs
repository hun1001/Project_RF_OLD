using Keyword;

namespace Item
{
    public class Item_Adrenaline : Item
    {
        private int _firstHpPercent = 0;
        private Tank.Tank_Damage _tankDamage = null;
        private Tank.Tank _tank = null;

        public override void AddItem()
        {
            transform.parent.TryGetComponent(out _tankDamage);
            _tankDamage.TryGetComponent(out _tank);
            _firstHpPercent = 100;

            EventManager.StartListening(EventKeyword.OnTankDamaged + transform.parent.GetComponent<Tank.Tank>().TankID, () =>
            {
                int percentDiff = (int)(_firstHpPercent - _tankDamage.CurrentHealthPercent);
                if (percentDiff > 0)
                {
                    _tank.UpgradeAllStat(percentDiff * 0.1f);
                }
            });
        }
    }
}
