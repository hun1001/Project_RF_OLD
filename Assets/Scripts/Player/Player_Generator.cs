using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Util;

public class Player_Generator : Base.CustomComponent<Player.Player>
{
    private void Awake()
    {
        GameObject tank = PoolManager.Instance.Get("Assets/Prefabs/Tanks/Tank_Tiger.prefab", Vector3.zero, Quaternion.identity);
        tank.GetComponent<Tank.Tank>().Assignment(new Tank.TankUserData(Instance.MoveJoyStick, Instance.HpBar));
        tank.GetComponent<Turret.Turret>().Assignment(new Turret.TurretUserData(Instance.AttackJoyStick, Instance.AttackImage, Instance.AttackCancel));
    }
}
