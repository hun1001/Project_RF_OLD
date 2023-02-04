using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.EventSystems;
using Cinemachine;
using Turret;

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

        private Vector3 _offsetDefalutPosition = Vector3.zero;
        private bool _isShakingPossible = false;
        private bool _isShakingEnd = false;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;

            _turretAttack = GameObject.FindGameObjectWithTag("PlayerTank").GetComponent<Turret_Attack>();
            _attackRange = _turretAttack.Range;

            _offsetDefalutPosition = _transposer.m_FollowOffset;
        }

        private void Update()
        {
            //CameraRotation();
            SnipingCamera();
            CameraShake();
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
            else if(_transposer.m_FollowOffset != _offsetDefalutPosition || _isShakingEnd == false)
            {
                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, _offsetDefalutPosition, 2f * Time.deltaTime);
            }
        }

        public void CameraShake()
        {
            if(_turretAttack.NextFire > 0 && _isShakingPossible == true)
            {
                float cameraPositionX = _attackJoyStick.Horizontal * -5f;
                float cameraPositionZ = _attackJoyStick.Vertical * -5f;
                Vector3 cameraPosition = _offsetDefalutPosition;
                cameraPosition.x += cameraPositionX;
                cameraPosition.z += cameraPositionZ;
                _transposer.m_FollowOffset = Vector3.Lerp(_transposer.m_FollowOffset, cameraPosition, 5f * Time.deltaTime);
                if(_isShakingEnd == false)
                {
                    _isShakingEnd = true;
                    Invoke("CameraShakeEnd", 0.2f);
                }
            }
            else if(_turretAttack.NextFire <= 0 && _isShakingPossible == false)
            {
                _isShakingPossible = true;
            }
        }

        private void CameraShakeEnd()
        {
            _isShakingPossible = false;
            _isShakingEnd = false;
        }
    }
}