using System;
using System.Collections;
using System.Collections.Generic;
using Tank;
using Turret;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Util;

namespace Player
{
    public class Player : Base.CustomGameObject
    {
        private JoyStick _moveJoyStick = null;
        public JoyStick MoveJoyStick => _moveJoyStick;

        private Bar _hpBar = null;
        public Bar HpBar => _hpBar;

         
        private JoyStick _attackJoyStick = null;
        public JoyStick AttackJoyStick => _attackJoyStick;

        private Image _attackImage = null;
        public Image AttackImage => _attackImage;

        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;
        
        private GameObject _tank = null;
        public GameObject Tank => _tank;
        

        private void Awake()
        {
            PlayCanvas playCanvas = FindObjectOfType<PlayCanvas>();

            _moveJoyStick = playCanvas.MoveJoyStick;
            _hpBar = playCanvas.HpBar;
            _attackJoyStick = playCanvas.AttackJoyStick;
            _attackImage = playCanvas.AttackImage;
            _attackCancel = playCanvas.AttackCancel;
            
            _tank = PoolManager.Instance.Get("Assets/Prefabs/Tanks/HeavyTank/Tank_Tiger.prefab", this.transform.position, Quaternion.identity);
            _tankMove = _tank.GetComponent<Tank_Move>();
            _turretRotate = _tank.GetComponent<Turret_Rotate>();
            
        }
        
        Tank_Move _tankMove = null;
        
        Turret_Rotate _turretRotate = null;
        

        private void Update()
        {
            _tankMove.Move(_moveJoyStick);
            _turretRotate.Rotate(_attackJoyStick);
        }
    }
}
