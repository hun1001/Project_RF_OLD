using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using Sound;
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
        private Image _attackImage = null;
        private AttackCancel _attackCancel = null;

        private float _shellSpeed = 1f;

        private float _range = 10f;

        protected float _fireRate = 1f;

        protected float _nextFire = 0f;

        private bool _isReload = false;

        protected override void Assignment()
        {
            base.Assignment();

            _firePoint = Instance.FirePoint;

            _joyStick = Instance.JoyStick;

            _attackImage = Instance.AttackImage;

            _attackCancel = Instance.AttackCancel;

            _shellSpeed = Instance.TurretSO.shellSpeed;

            _range = Instance.TurretSO.attackRange;

            _fireRate = Instance.TurretSO.reloadSpeed;

            _joyStick.AddOnPointerUpListener(Fire);
        }

        protected virtual void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }
            if(_isReload == true && _nextFire < Instance._reloadSound.length - 0.5f)
            {
                _isReload = false;
                SoundManager.Instance.PlaySound(Instance._reloadSound, SoundType.SFX, 0.6f);
            }

            _attackImage.fillAmount = 1f - _nextFire / _fireRate;
        }

        public virtual void Fire()
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
            _isReload = true;

            SoundManager.Instance.PlaySound(Instance._fireSound, SoundType.SFX);
            var shell = PoolManager.Instance.Get("Assets/Prefabs/Shell/Shell.prefab", _firePoint.position, _firePoint.rotation);
            shell.SendMessage("SetSpeed", _shellSpeed);
            shell.SendMessage("SetRange", _range);
            Invoke("ShellDropSoundPlay", 0.6f);
        }

        private void ShellDropSoundPlay()
        {
            SoundManager.Instance.PlaySound(Instance._shellDropSound, SoundType.SFX, 0.5f);
        }

        public float Range => _range;
        public float NextFire => _nextFire;
    }
}
