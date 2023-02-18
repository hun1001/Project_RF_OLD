using System;
using CameraSpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Scene;
using Tank;
using Turret;
using Keyword;
using Util;

namespace Player
{
    public class Player : Base.CustomGameObject<Player>
    {
        [SerializeField]
        private ControllerCanvas _controllerCanvas = null;
        
        [SerializeField]
        private CameraManager _cameraManager = null;
        
        private Tank.Tank _player = null;

        private void Awake()
        {
            _player = PoolManager.Instance.Get<Tank.Tank>("Assets/Prefabs/Tanks/HeavyTank/Tank_Tiger.prefab", this.transform);
            
            _player.transform.SetParent(null);
            
            _cameraManager.SetPlayer(_player.transform);
            
            Turret_Attack attack = _player.GetComponent<Turret_Attack>();
            EventManager.StartListening(EventKeyword.OnPointerDownAttackJoyStick, attack.Fire);
            
            Turret_AimLine aimLine = _player.GetComponent<Turret_AimLine>();
            EventManager.StartListening(EventKeyword.OnPointerDownAttackJoyStick, aimLine.OnAimStart);
            EventManager.StartListening(EventKeyword.OnPointerUpAttackJoyStick, aimLine.OnAimEnd);
        }

        private void Update()
        {
            Tank_Move move = _player.GetComponent<Tank_Move>();
            move.Move(_controllerCanvas.MoveJoyStick);
            
            Turret_Attack attack = _player.GetComponent<Turret_Attack>();
            //_controllerCanvas.AttackImage.fillAmount = 1f - attack.NextFire / attack.FireRate;
            
            Turret_Rotation rotation = _player.GetComponent<Turret_Rotation>();
            rotation.Rotate(_controllerCanvas.AttackJoyStick);
        }
    }
}
