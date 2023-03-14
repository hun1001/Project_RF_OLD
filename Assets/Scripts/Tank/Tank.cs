using UnityEngine;

namespace Tank
{
    public class Tank : Base.CustomGameObject<Tank>
    {
        [Header("Data")]
        [SerializeField]
        private SO.TankSO _tankSO = null;

        public Sprite TankSprite => _tankSO.tankSprite;

        private float _hp;
        public float Hp => _hp;
        private float _armour;
        public float Armour => _armour;
        private float _maxSpeed;
        public float MaxSpeed => _maxSpeed;
        private float _acceleration;
        public float Acceleration => _acceleration;
        private float _rotationSpeed;
        public float RotationSpeed => _rotationSpeed;

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
            _hp = _tankSO.hp;
            _armour = _tankSO.armour;
            _maxSpeed = _tankSO.maxSpeed;
            _acceleration = _tankSO.acceleration;
            _rotationSpeed = _tankSO.rotationSpeed;
        }

        public void UpgradeAllStat(float percent)
        {
            
        }

        public void UpgradeHpStat(float percent)
        {
            percent = percent * 0.01f;
            _hp = _tankSO.hp + _tankSO.hp * percent;
        }

        public void UpgradeSpeedStat(float percent)
        {
            percent = percent * 0.01f;
            _maxSpeed = _tankSO.maxSpeed + _tankSO.maxSpeed * percent;
        }

        public void UpgradeAccelerationStat(float percent)
        {
            percent = percent * 0.01f;
            _acceleration = _tankSO.acceleration + _tankSO.acceleration * percent;
        }

        public void UpgradeRotationSpeedStat(float percent)
        {
            percent = percent * 0.01f;
            _rotationSpeed = _tankSO.rotationSpeed + _tankSO.rotationSpeed * percent;
        }
    }
}
