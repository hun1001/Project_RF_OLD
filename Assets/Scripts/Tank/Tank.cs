using UnityEngine;

namespace Tank
{
    public class Tank : Base.CustomGameObject<Tank>
    {
        [Header("Data")]
        [SerializeField]
        private SO.TankSO _tankSO = null;

        public Sprite TankSprite => _tankSO.tankSprite;

        public float Hp => _tankSO.hp;
        public float Armour => _tankSO.armour;
        public float MaxSpeed => _tankSO.maxSpeed;
        public float Acceleration => _tankSO.acceleration;
        public float RotationSpeed => _tankSO.rotationSpeed;

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
        public AudioClip _moveSound = null;
        public AudioClip _trackSound = null;
        public AudioClip _loadSound = null;

        private uint _tankID = 0;

        public uint TankID
        {
            get => _tankID;
            set => _tankID = _tankID == 0 ? value : _tankID;
        }

        public void UpgradeStat(float percent)
        {
            percent /= 100;
            _tankSO.hp += _tankSO.hp * percent;
            _tankSO.maxSpeed += _tankSO.maxSpeed * percent;
            _tankSO.acceleration += _tankSO.acceleration * percent;
            _tankSO.rotationSpeed += _tankSO.rotationSpeed * percent;
            Debug.Log("Upgrade Stat");
        }
    }
}
