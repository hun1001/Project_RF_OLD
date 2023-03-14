using Sound;
using System.Collections;
using UnityEngine;
using Util;

namespace Turret
{
    public class Turret_Attack : Base.CustomComponent<Turret>
    {
        private Transform _firePoint = null;

        private float _shellSpeed = 1f;

        private float _range = 10f;
        public float Range => _range;

        private float _fireRate = 1f;
        public float FireRate => _fireRate;

        private float _nextFire = 0f;
        public float NextFire => _nextFire;

        private bool _isReload = false;

        #region AI Variable
        private bool _isFire = false;

        private Tank.Tank_Move _tankMove = null;
        #endregion

        protected void Awake()
        {
            _firePoint = Instance.FirePoint;

            _shellSpeed = Instance.TurretSO.shellSpeed;

            _range = Instance.TurretSO.attackRange;

            _fireRate = Instance.TurretSO.reloadSpeed;

            if (CompareTag("PlayerTank"))
            {
                StartCoroutine(PlayerUpdateLogic());
            }
            else
            {
                _tankMove = GetComponent<Tank.Tank_Move>();
                StartCoroutine(LateUpdateLogic());
            }
        }

        #region Player Function
        private IEnumerator PlayerUpdateLogic()
        {
            while (true)
            {
                if (_nextFire > 0)
                {
                    _nextFire -= Time.deltaTime;
                }
                if (_isReload == true && _nextFire < Instance._reloadSound.length - 0.5f)
                {
                    _isReload = false;
                    SoundManager.Instance.PlaySound(Instance._reloadSound, SoundType.SFX, 0.5f);
                }
                yield return null;
            }
        } 

        public virtual void Fire()
        {
            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;
            _isReload = true;

            SoundManager.Instance.PlaySound(Instance._fireSound, SoundType.SFX, 0.7f);
            var shell = PoolManager.Instance.Get("Shell", _firePoint.position, _firePoint.rotation);
            shell.SendMessage("SetSpeed", _shellSpeed);
            shell.SendMessage("SetRange", _range);
            Invoke("ShellDropSoundPlay", 0.6f);
        }

        private void ShellDropSoundPlay()
        {
            SoundManager.Instance.PlaySound(Instance._shellDropSound, SoundType.SFX, 0.5f);
        }
        #endregion

        #region AI Function
        private IEnumerator LateUpdateLogic()
        {
            while (true)
            {
                if(_tankMove.State == Tank.TankStateType.Attack)
                {
                    StartCoroutine(AiFireCoroutine());
                }
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator AiFireCoroutine()
        {
            if (_isFire == true)
            {
                yield break;
            }

            _isFire = true;

            float fireTime = 0f;

            while (_tankMove.State == Tank.TankStateType.Attack)
            {
                fireTime += Time.deltaTime;
                if (fireTime > 1f)
                {
                    fireTime = 0f;
                    var shell = PoolManager.Instance.Get("Shell", _firePoint.position, _firePoint.rotation);
                    shell.SendMessage("SetSpeed", 20f);
                    shell.SendMessage("SetRange", 20f);
                }
                yield return null;
            }

            _isFire = false;
        }
        #endregion
    }
}
