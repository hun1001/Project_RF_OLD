using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.EventSystems;
using Cinemachine;
using Turret;
using Tank;

namespace CameraManage
{
    public class Camera_Move : CameraComponent
    {
        private CinemachineVirtualCamera _cmvcam = null;
        private CinemachineTransposer _transposer = null;

        private JoyStick _joyStick = null;
        private JoyStick _attackJoyStick = null;

        private Turret_Attack _turretAttack = null;
        private float _attackRange = 0.0f;

        [Header("Rebound")]
        [SerializeField]
        private float _reboundDistance = 5f;
        private Vector3 _offsetDefalutPosition = Vector3.zero;
        private bool _isReboundingPossible = false;
        private bool _isReboundingEnd = false;

        [Header("Hit Shake")]
        [SerializeField]
        private float _hitShakeDuration = 0.3f;
        [SerializeField]
        private float _hitShakeDistance = 0.05f;
        private Tank_DamageWithHPBar _tank_damage = null;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;

            _turretAttack = GameObject.FindGameObjectWithTag("PlayerTank").GetComponent<Turret_Attack>();
            _attackRange = _turretAttack.Range;

            _tank_damage = GameObject.FindGameObjectWithTag("PlayerTank").GetComponent<Tank_DamageWithHPBar>();

            _offsetDefalutPosition = _transposer.m_FollowOffset;
        }

        private void Update()
        {
            //CameraRotation();
            SnipingCamera();
            FireCameraRebound();
            HitCameraShake();
        }

        private void CameraRotation()
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (_joyStick.IsDragging == false && _attackJoyStick.IsDragging == false)
                {
                    if (Input.GetMouseButton(0))
                    {
                        //_cmvcam.m_Lens.Dutch = 0f;
                    }
                }
            }
        }

        private void SnipingCamera()
        {
            if(_attackJoyStick.IsDragging == true)
            {
                if(_attackJoyStick.DragTime >= 3f)
                {
                    Vector3 offset = _offsetDefalutPosition;
                    Vector3 direction = new Vector3(_attackJoyStick.Direction.x * _attackRange * 0.25f, 0f, _attackJoyStick.Direction.y * _attackRange * 0.25f);
                    offset += direction;

                    _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
                }
            }
            else if(_transposer.m_FollowOffset != _offsetDefalutPosition || _isReboundingEnd == false)
            {
                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, _offsetDefalutPosition, 2f * Time.deltaTime);
            }
        }

        public void FireCameraRebound()
        {
            if(_turretAttack.NextFire > 0 && _isReboundingPossible == true)
            {
                float cameraPositionX = _attackJoyStick.Horizontal * -1f * _reboundDistance;
                float cameraPositionZ = _attackJoyStick.Vertical * -1f * _reboundDistance;
                Vector3 cameraPosition = _offsetDefalutPosition;
                cameraPosition.x += cameraPositionX;
                cameraPosition.z += cameraPositionZ;
                _transposer.m_FollowOffset = Vector3.Lerp(_transposer.m_FollowOffset, cameraPosition, 5f * Time.deltaTime);
                if(_isReboundingEnd == false)
                {
                    _isReboundingEnd = true;
                    Invoke("CameraReboundEnd", 0.2f);
                }
            }
            else if(_turretAttack.NextFire <= 0 && _isReboundingPossible == false)
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
            if(_tank_damage.IsHit == true)
            {
                _tank_damage.IsHit = false;
                InvokeRepeating("HitStartShake", 0f, 0.005f);
                Invoke("HitStopShake", _hitShakeDuration);
            }
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
            _transposer.m_FollowOffset = _offsetDefalutPosition;
        }
    }
}