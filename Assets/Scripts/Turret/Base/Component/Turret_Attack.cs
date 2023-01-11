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
        private AttackCancel _attackCancel = null;

        private float _shellSpeed = 1f;

        private float _range = 10f;

        protected float _fireRate = 1f;

        protected float _nextFire = 0f;

        private void Awake()
        {
            _firePoint = Instance.FirePoint;
            _joyStick = Instance.JoyStick;
            _fireImage = Instance.Image;
            _attackCancel = Instance.AttackCancel;

            _shellSpeed = Instance.TurretSO.shellSpeed;

            _range = Instance.TurretSO.attackRange;

            _fireRate = Instance.TurretSO.reloadSpeed;
        }

        protected virtual void Start()
        {
            _joyStick.AddOnPointerUpListener(Fire);
        }

        protected virtual void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }

            _fireImage.fillAmount = 1f - _nextFire / _fireRate;
        }

        public void Fire()
        {
            if (_attackCancel.IsCancelAttack == true)
            {
                _attackCancel.CancelAttackReset();
                return;
            }

            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;

            PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position, _firePoint.rotation).SendMessage("SetSpeed", _shellSpeed);
        }
    }
}
