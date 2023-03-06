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

        private Tank.Tank _playerTank = null;
        public Tank.Tank PlayerTank => _playerTank;

        private Turret.Turret _playerTurret = null;
        public Turret.Turret PlayerTurret => _playerTurret;

        private void Awake()
        {
            GameObject tank = PoolManager.Instance.Get("Assets/Prefabs/Tanks/HeavyTank/Tank_Tiger.prefab", this.transform);
            _playerTank = tank.GetComponent<Tank.Tank>();
            _playerTurret = tank.GetComponent<Turret.Turret>();
            tank.tag = "PlayerTank";

            _playerTank.TankID = 1;

            _playInformationCanvas.HpBar.MaxValue = _playerTank.Hp;

            _cameraManager.SetPlayer(_playerTank.transform);

            Turret_Attack attack = _playerTank.GetComponent<Turret_Attack>();
            EventManager.StartListening(EventKeyword.OnMainBatteryFire, attack.Fire);

            Turret_AimLine aimLine = _playerTank.GetComponent<Turret_AimLine>();
            EventManager.StartListening(EventKeyword.OnPointerDownAttackJoyStick, aimLine.OnAimStart);
            EventManager.StartListening(EventKeyword.OnPointerUpAttackJoyStick, aimLine.OnAimEnd);

            EventManager.StartListening(EventKeyword.OnTankDamaged + _playerTank.TankID, (dmg) =>
            {
                float damage = (float)dmg[0];
                _playInformationCanvas.HpBar.Value -= damage;
                GetComponent<Camera_Move>().HitCameraShake();
            });

            foreach (Button button in _controllerCanvas.SkillButtons)
            {
                button.onClick.AddListener(() => _playerTank.GetComponent<Tank_Skill>().Skill());
            }

            EventManager.StartListening(EventKeyword.OnTankDestroyed + _playerTank.TankID, () =>
            {
                FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Result);
            });
        }

        private void Update()
        {
            Tank_Move move = _playerTank.GetComponent<Tank_Move>();
            move.Move(_controllerCanvas.MoveJoyStick);

            Turret_Attack attack = _playerTank.GetComponent<Turret_Attack>();
            _controllerCanvas.AttackJoyStick.AttackButtonImage.fillAmount = 1f - attack.NextFire / attack.FireRate;

            Turret_Rotation rotation = _playerTank.GetComponent<Turret_Rotation>();
            rotation.Rotate(_controllerCanvas.AttackJoyStick);

            var c = _cameraManager.GetComponent<Camera_Move>();
            c.SnipingCamera(_controllerCanvas.AttackJoyStick);
            c.FireCameraRebound(_controllerCanvas.AttackJoyStick);
        }
    }
}
