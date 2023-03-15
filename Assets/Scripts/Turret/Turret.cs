using UnityEngine;
using UI;
using UnityEngine.UI;

namespace Turret
{
    public class Turret : Base.CustomGameObject<Turret>
    {
        [Header("Data")]
        [SerializeField]
        private SO.TurretSO _turretSO = null;

        private float _rotationSpeed = 0f;
        public float RotationSpeed => _rotationSpeed;
        private float _permanentRotationSpeed = 0f;

        private float _reloadSpeed = 0f;
        public float ReloadSpeed => _reloadSpeed;
        private float _permanentReloadSpeed = 0f;

        private float _shellSpeed = 0f;
        public float ShellSpeed => _shellSpeed;
        private float _permanentShellSpeed = 0f;

        private float _attackRange = 0f;
        public float AttackRange => _attackRange;
        private float _permanentAttackRange = 0f;


        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;

        [SerializeField]
        private Transform _firePoint = null;
        public Transform FirePoint => _firePoint;

        [Header("Sound")]
        public AudioClip FireSound = null;
        public AudioClip ReloadSound = null;
        public AudioClip ShellDropSound = null;

        private void Awake()
        {
            SettingStat();
        }

        private void SettingStat()
        {
            _rotationSpeed = _turretSO.rotationSpeed + _permanentRotationSpeed;
            _reloadSpeed = _turretSO.reloadSpeed + _permanentReloadSpeed;
            _shellSpeed = _turretSO.shellSpeed + _permanentShellSpeed;
            _attackRange = _turretSO.attackRange + _permanentAttackRange;
        }

        public void TurretUpgradeStat(TurretStatType statType, float percent)
        {
            percent *= 0.01f;

            switch (statType)
            {
                case TurretStatType.RotationSpeed:
                    {
                        _permanentRotationSpeed += _turretSO.rotationSpeed * percent;
                    }
                    break;
                case TurretStatType.ReloadSpeed:
                    {
                        _permanentReloadSpeed += _turretSO.reloadSpeed * percent;
                    }
                    break;
                case TurretStatType.ShellSpeed:
                    {
                        _permanentShellSpeed += _turretSO.shellSpeed * percent;
                    }
                    break;
                case TurretStatType.AttackRange:
                    {
                        _permanentAttackRange += _turretSO.attackRange * percent;
                    }
                    break;
                default:
                    break;
            }

            SettingStat();
        }
    }
}
