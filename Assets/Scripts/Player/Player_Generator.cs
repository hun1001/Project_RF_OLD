using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Player
{
    public class Player_Generator : PlayerComponent
    {
        private void Awake()
        {
            GameObject tank = PoolManager.Instance.Get("Assets/Prefabs/Tanks/Tank_Tiger.prefab", Vector3.zero, Quaternion.identity);
            tank.GetComponent<Tank.Tank>().Assignment(new Tank.TankUserData(Instance.MoveJoyStick, Instance.HpBar));
            tank.GetComponent<Turret.Turret>().Assignment(new Turret.TurretUserData(Instance.AttackJoyStick, Instance.AttackImage, Instance.AttackCancel));
        }
    }
}