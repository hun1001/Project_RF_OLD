using UnityEngine;
using UI;
using Cinemachine;
using Turret;
using Tank;

namespace CameraSpace
{
    public class Camera_Move : Base.CustomComponent<CameraManager>
    {
        private CinemachineVirtualCamera _cmvcam = null;
        private CinemachineTransposer _transposer = null;

        [SerializeField]
        private Turret_Attack _turretAttack = null;
        private Turret_Attack _TurretAttack
        {
            get
            {
                if(_turretAttack == null)
                {
                    GameObject.FindGameObjectWithTag("PlayerTank")?.TryGetComponent(out _turretAttack);
                }
                return _turretAttack;
            }
            set
            {
                _turretAttack = value;
            }
        }
        private float _attackRange = 0.0f;

        [Header("Rebound")]
        [SerializeField]
        private float _reboundDistance = 5f;
        private Vector3 _offsetDefalutPosition = Vector3.zero;
        private Vector3 _OffsetDefalutPosition
        {
            get
            {
                if (_offsetDefalutPosition == Vector3.zero)
                {
                    _offsetDefalutPosition = _transposer.m_FollowOffset;
                }
                return _offsetDefalutPosition;
            }
        }
        private bool _isReboundingPossible = false;
        private bool _isReboundingEnd = false;

        [Header("Hit Shake")]
        [SerializeField]
        private float _hitShakeDuration = 0.3f;
        [SerializeField]
        private float _hitShakeDistance = 0.05f;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            GameObject.FindGameObjectWithTag("PlayerTank")?.TryGetComponent(out _turretAttack);

            _offsetDefalutPosition = _transposer.m_FollowOffset;
        }

        private void Start()
        {
            _attackRange = _TurretAttack.Range;
        }

        public void SnipingCamera(JoyStick joyStick)
        {
            if (joyStick.IsDragging == true)
            {
                if (joyStick.DragTime >= 3f)
                {
                    Vector3 offset = _OffsetDefalutPosition;
                    Vector3 direction = new Vector3(joyStick.Direction.x * _attackRange * 0.25f, 0f, joyStick.Direction.y * _attackRange * 0.25f);
                    offset += direction;

                    _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
                }
            }
            else if (_transposer.m_FollowOffset != _OffsetDefalutPosition || _isReboundingEnd == false)
            {
                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, _OffsetDefalutPosition, 2f * Time.deltaTime);
            }
        }

        public void FireCameraRebound(JoyStick joyStick)
        {
            if (_TurretAttack.NextFire > 0 && _isReboundingPossible == true)
            {
                Debug.Log("Rebound");
                float cameraPositionX = joyStick.Horizontal * -1f * _reboundDistance;
                float cameraPositionZ = joyStick.Vertical * -1f * _reboundDistance;
                Vector3 cameraPosition = _OffsetDefalutPosition;
                cameraPosition.x += cameraPositionX;
                cameraPosition.z += cameraPositionZ;
                _transposer.m_FollowOffset = Vector3.Lerp(_transposer.m_FollowOffset, cameraPosition, 5f * Time.deltaTime);
                if (_isReboundingEnd == false)
                {
                    _isReboundingEnd = true;
                    Invoke("CameraReboundEnd", 0.2f);
                }
            }
            else if (_TurretAttack.NextFire <= 0 && _isReboundingPossible == false)
            {
                _isReboundingPossible = true;
            }
        }

        private void CameraReboundEnd()
        {
            _isReboundingPossible = false;
            _isReboundingEnd = false;
        }

        public void HitCameraShake()
        {
            InvokeRepeating("HitStartShake", 0f, 0.005f);
            Invoke("HitStopShake", _hitShakeDuration);
        }

        private void HitStartShake()
        {
            float cameraPosX = Random.value * _hitShakeDistance * 2 - _hitShakeDistance;
            float cameraPosZ = Random.value * _hitShakeDistance * 2 - _hitShakeDistance;
            Vector3 cameraPos = _transposer.m_FollowOffset;
            cameraPos.x += cameraPosX;
            cameraPos.z += cameraPosZ;
            _transposer.m_FollowOffset = cameraPos;
        }
        private void HitStopShake()
        {
            CancelInvoke("HitStartShake");
            _transposer.m_FollowOffset = _OffsetDefalutPosition;
        }
    }
}
