using Tank;

namespace Item
{
    public class Item_HighEnergy : Item
    {
        public override void AddItem()
        {
            transform.parent.GetComponent<Tank.Tank>().TankUpgradePermanentStat(TankStatType.Acceleration, 10f);
        }
    }
}
