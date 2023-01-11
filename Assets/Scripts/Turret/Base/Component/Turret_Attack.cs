using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using Util;

namespace Turret
{
    public class Turret_Attack : TurretComponent
    {
        private Transform _firePoint = null;
        private JoyStick _joyStick = null;
        private Image _fireImage = null;

        private float _range = 10f;

        private float _fireRate = 1f;

        private float _nextFire = 0f;

        private void Awake()
        {
            _firePoint = Instance.FirePoint;
            _joyStick = Instance.JoyStick;
            _fireImage = Instance.Image;

            _range = Instance.TurretSO.attackRange;

            _fireRate = Instance.TurretSO.reloadSpeed;
        }

        private void Start()
        {
            _joyStick.AddOnPointerUpListener(Fire);
        }

        private void Fire()
        {
            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;

            PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position);
        }

        private void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }

            _fireImage.fillAmount = 1f - _nextFire / _fireRate;
        }
    }
}
