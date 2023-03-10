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
        private Camera_Move _cameraMove = null;

        private Tank.Tank _playerTank = null;
        public Tank.Tank PlayerTank => _playerTank;

        private Turret.Turret _playerTurret = null;
        public Turret.Turret PlayerTurret => _playerTurret;

        private Tank_Move _move = null;
        private Turret_Attack _attack = null;
        private Turret_Rotation _rotation = null;

        private void Awake()
        {
            GameObject tank = PoolManager.Instance.Get(PlayerPrefs.GetString(PlayerPrefabsKey.PlayerTankKey), this.transform);
            tank.TryGetComponent(out _playerTank);
            tank.TryGetComponent(out _playerTurret);
            tank.tag = "PlayerTank";

            _playerTank.TankID = 1;

            _playInformationCanvas.HpBar.MaxValue = _playerTank.Hp;

            _cameraManager.SetPlayer(_playerTank.transform);
            _cameraManager.TryGetComponent(out _cameraMove);

            _playerTank.TryGetComponent(out _move);
            _playerTank.TryGetComponent(out _attack);
            _playerTank.TryGetComponent(out _rotation);

            EventManager.StartListening(EventKeyword.OnMainBatteryFire, _attack.Fire);

            _playerTank.TryGetComponent<Turret_AimLine>(out var aimLine);
            EventManager.StartListening(EventKeyword.OnPointerDownAttackJoyStick, aimLine.OnAimStart);
            EventManager.StartListening(EventKeyword.OnPointerUpAttackJoyStick, aimLine.OnAimEnd);

            EventManager.StartListening(EventKeyword.OnTankDamaged + _playerTank.TankID, (dmg) =>
            {
                float damage = (float)dmg[0];
                _playInformationCanvas.HpBar.Value -= damage;
                if (damage >= 0f)
                {
                    _cameraManager.GetComponent<Camera_Move>().HitCameraShake();
                }
            });

            foreach (Button button in _controllerCanvas.SkillButtons)
            {
                button.onClick.AddListener(() => _playerTank.GetComponent<Tank_Skill>().Skill());
            }

            EventManager.StartListening(EventKeyword.OnTankDestroyed + _playerTank.TankID, () =>
            {
                FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.Result, CanvasNameKeyword.PlayInformationCanvas);
            });

            //StartCoroutine(nameof(UpdateLogic));
        }

        //private IEnumerator UpdateLogic()
        //{
        //    while (true)
        //    {
        //        Tank_Move move = _playerTank.GetComponent<Tank_Move>();
        //        move.Move(_controllerCanvas.MoveJoyStick);

        //        Turret_Attack attack = _playerTank.GetComponent<Turret_Attack>();
        //        _controllerCanvas.AttackJoyStick.AttackButtonImage.fillAmount = 1f - attack.NextFire / attack.FireRate;

        //        Turret_Rotation rotation = _playerTank.GetComponent<Turret_Rotation>();
        //        rotation.Rotate(_controllerCanvas.AttackJoyStick);
        //        yield return null;
        //    }
        //}

        private void Update()
        {
            _move.Move(_controllerCanvas.MoveJoyStick);

            _controllerCanvas.AttackJoyStick.AttackButtonImage.fillAmount = 1f - _attack.NextFire / _attack.FireRate;

            _rotation.Rotate(_controllerCanvas.AttackJoyStick);
        }

        private void LateUpdate()
        {
            _cameraMove.SnipingCamera(_controllerCanvas.AttackJoyStick);
            _cameraMove.FireCameraRebound(_controllerCanvas.AttackJoyStick);
        }
    }
}
