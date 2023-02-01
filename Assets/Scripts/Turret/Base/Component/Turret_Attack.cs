using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using Util;

namespace Turret
{
    public class Turret_Attack : Base.CustomComponent<Turret>
    {
        protected Transform _firePoint = null;
        private JoyStick _joyStick = null;
        private JoyStick _snipingJoyStick = null;
        private Image _attackImage = null;
        private Image _snipingImage = null;
        private AttackCancel _attackCancel = null;
        private AttackCancel _snipingCancel = null;

        private float _shellSpeed = 1f;

        private float _range = 10f;

        protected float _fireRate = 1f;

        protected float _nextFire = 0f;

        protected override void Assignment()
        {
            base.Assignment();

            _firePoint = Instance.FirePoint;

            _joyStick = Instance.JoyStick;
            _snipingJoyStick = Instance.SnipingJoyStick;

            _attackImage = Instance.AttackImage;
            _snipingImage = Instance.SnipingImage;

            _attackCancel = Instance.AttackCancel;
            _snipingCancel = Instance.SnipingCancel;

            _shellSpeed = Instance.TurretSO.shellSpeed;

            _range = Instance.TurretSO.attackRange;

            _fireRate = Instance.TurretSO.reloadSpeed;

            _joyStick.AddOnPointerUpListener(Fire);
            _snipingJoyStick.AddOnPointerUpListener(Fire);
        }

        protected virtual void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }

            _attackImage.fillAmount = 1f - _nextFire / _fireRate;
            _snipingImage.fillAmount = 1f - _nextFire / _fireRate;
        }

        public virtual void Fire()
        {
            if (_attackCancel.IsCancelAttack == true)
            {
                _attackCancel.CancelAttackReset();
                return;
            }
            else if(_snipingCancel.IsCancelAttack == true)
            {
                _snipingCancel.CancelAttackReset();
                return;
            }

            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;

            var shell = PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position, _firePoint.rotation);
            shell.SendMessage("SetSpeed", _shellSpeed);
            shell.SendMessage("SetRange", _range);
        }

        public float Range => _range;
        public float NextFire => _nextFire;
    }
}
