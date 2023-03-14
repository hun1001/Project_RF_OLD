using Turret;

namespace Item
{
    public class Item_HighEnergypack : Item
    {
        public override void AddItem()
        {
            transform.parent.GetComponent<Turret.Turret>().TurretUpgradeStat(TurretStatType.RotationSpeed, 10f);
        }
    }
}
