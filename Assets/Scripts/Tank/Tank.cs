using UnityEngine;

namespace Tank
{
    public class Tank : Base.CustomGameObject<Tank>
    {
        [Header("Data")]
        [SerializeField]
        private SO.TankSO _tankSO = null;

        public Sprite TankSprite => _tankSO.tankSprite;

        #region Tank Stat

        // Permanent - 영구적인 / Impermanent - 비영구적인

        #region HP
        private float _hp;
        public float Hp => _hp;
        private float _impermanentHp = 0f;
        private float _permanentHp = 0f;
        #endregion

        #region Armour
        private float _armour;
        public float Armour => _armour;
        private float _impermanentArmour = 0f;
        private float _permanentArmour = 0f;
        #endregion

        #region MaxSpeed
        private float _maxSpeed;
        public float MaxSpeed => _maxSpeed;
        private float _impermanentMaxSpeed = 0f;
        private float _permanentMaxSpeed = 0f;
        #endregion

        #region Acceleration
        private float _acceleration;
        public float Acceleration => _acceleration;
        private float _impermanentAcceleration = 0f;
        private float _permanentAcceleration = 0f;
        #endregion

        #region RotationSpeed
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;
        private float _impermanentRotationSpeed = 0f;
        private float _permanentRotationSpeed = 0f;
        #endregion
        #endregion

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;

        [Header("Skid")]
        [SerializeField]
        private LineRenderer[] _lineRenderer = null;
        public LineRenderer[] LineRenderer => _lineRenderer;

        [SerializeField]
        private Transform[] _skidMark = null;
        public Transform[] SkidMark => _skidMark;

        [Header("Sound")]
        public AudioClip MoveSound = null;
        public AudioClip TrackSound = null;
        public AudioClip LoadSound = null;

        private uint _tankID = 0;

        public uint TankID
        {
            get => _tankID;
            set => _tankID = _tankID == 0 ? value : _tankID;
        }

        private void Awake()
        {
            SettingStat();
        }

        private void SettingStat()
        {
            _hp = _tankSO.hp + _impermanentHp + _permanentHp;
            _armour = _tankSO.armour + _impermanentArmour + _permanentArmour;
            _maxSpeed = _tankSO.maxSpeed + _impermanentMaxSpeed + _permanentMaxSpeed;
            _acceleration = _tankSO.acceleration + _impermanentAcceleration + _permanentAcceleration;
            _rotationSpeed = _tankSO.rotationSpeed + _impermanentRotationSpeed + _permanentRotationSpeed;
        }

        public void UpgradeAllStat(float percent)
        {
            percent *= 0.01f;

            _impermanentHp = _tankSO.hp * percent;
            _impermanentMaxSpeed = _tankSO.maxSpeed * percent;
            _impermanentAcceleration = _tankSO.acceleration * percent;
            _impermanentRotationSpeed = _tankSO.rotationSpeed * percent;

            SettingStat();
        }

        public void TankUpgradePermanentStat(TankStatType statType, float percent)
        {
            percent *= 0.01f;

            switch (statType)
            {
                case TankStatType.Hp:
                    {
                        _permanentHp += _tankSO.hp * percent;
                    }
                    break;
                case TankStatType.Armour:
                    {
                        _permanentArmour += _tankSO.armour * percent;
                    }
                    break;
                case TankStatType.MaxSpeed:
                    {
                        _permanentMaxSpeed += _tankSO.maxSpeed * percent;
                    }
                    break;
                case TankStatType.Acceleration:
                    {
                        _permanentAcceleration += _tankSO.acceleration * percent;
                    }
                    break;
                case TankStatType.RotationSpeed:
                    {
                        _permanentRotationSpeed += _tankSO.rotationSpeed * percent;
                    }
                    break;
                default:
                    break;
            }

            SettingStat();
        }
    }
}
