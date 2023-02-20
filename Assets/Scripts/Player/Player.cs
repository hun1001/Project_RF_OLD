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
        private PlayInformationCanvas _playInformationCanvas = null;
        
        [SerializeField]
        private CameraManager _cameraManager = null;
        
        private Tank.Tank _player = null;

        private void Awake()
        {
            _player = PoolManager.Instance.Get<Tank.Tank>("Assets/Prefabs/Tanks/HeavyTank/Tank_Tiger.prefab", this.transform);
            
            _player.transform.SetParent(null);
            
            _player.tag = "PlayerTank";
            _player.TankID = 1;
            
            _playInformationCanvas.HpBar.MaxValue = _player.Hp;
            Debug.Log(_player.Hp);
            
            _cameraManager.SetPlayer(_player.transform);
            
            Turret_Attack attack = _player.GetComponent<Turret_Attack>();
            EventManager.StartListening(EventKeyword.OnMainBatteryFire, attack.Fire);
            
            Turret_AimLine aimLine = _player.GetComponent<Turret_AimLine>();
            EventManager.StartListening(EventKeyword.OnPointerDownAttackJoyStick, aimLine.OnAimStart);
            EventManager.StartListening(EventKeyword.OnPointerUpAttackJoyStick, aimLine.OnAimEnd);
            
            EventManager.StartListening(EventKeyword.OnTankDamaged + _player.TankID, (dmg) =>
            {
                float damage = (float)dmg[0];
                _playInformationCanvas.HpBar.Value -= damage;
            });

            foreach (Button button in _controllerCanvas.SkillButtons)
            {
                button.onClick.AddListener(() => _player.GetComponent<Tank_Skill>().Skill());
            }
        }

        private void Update()
        {
            Tank_Move move = _player.GetComponent<Tank_Move>();
            move.Move(_controllerCanvas.MoveJoyStick);
            
            Turret_Attack attack = _player.GetComponent<Turret_Attack>();
            _controllerCanvas.AttackJoyStick.AttackButtonImage.fillAmount = 1f - attack.NextFire / attack.FireRate;

            Turret_Rotation rotation = _player.GetComponent<Turret_Rotation>();
            rotation.Rotate(_controllerCanvas.AttackJoyStick);
        }
    }
}
