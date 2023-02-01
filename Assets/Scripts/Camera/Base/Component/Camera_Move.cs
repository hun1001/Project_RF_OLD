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
        private JoyStick _snipingJoyStick = null;
        private AttackCancel _attackCancel = null;
        private AttackCancel _snipingCancel = null;

        private Turret_Attack _turretAttack = null;
        private float _attackRange = 0.0f;

        private Vector3 _offsetDefalutPosition = Vector3.zero;
        private float _offsetYDefault = 0.0f;
        [SerializeField]
        [Range(0.01f, 0.1f)]
        private float shakeRange = 0.05f;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;
            _snipingJoyStick = Instance.SnipingJoyStick;
            _attackCancel = Instance.AttackCancel;
            _snipingCancel = Instance.SnipingCancel;

            _turretAttack = GameObject.FindGameObjectWithTag("PlayerTank").GetComponent<Turret_Attack>();
            _attackRange = _turretAttack.Range;

            _offsetDefalutPosition = _transposer.m_FollowOffset;
            _offsetYDefault = _offsetDefalutPosition.y;
        }

        private void Update()
        {
            //CameraRotation();
            SnipingCamera();
        }

        private void CameraRotation()
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                if (_joyStick.IsDragging == false && _attackJoyStick.IsDragging == false && _snipingJoyStick.IsDragging == false)
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
            if(_snipingJoyStick.IsDragging == true)
            {
                Vector3 offset = _transposer.m_FollowOffset;
                float yPos = _offsetYDefault * (_attackRange / 40f);
                if (yPos < _offsetYDefault) yPos = _offsetYDefault;
                offset.y = yPos;

                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
            }
            else if(_transposer.m_FollowOffset.y != _offsetYDefault)
            {
                Vector3 offset = _transposer.m_FollowOffset;
                offset.y = _offsetYDefault;

                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
            }
        }

        public void CameraShake()
        {

            if(_turretAttack.NextFire > 0)
            {
                return;
            }

            float cameraPositionX = Random.value * shakeRange * 2 - shakeRange;
            float cameraPositionZ = Random.value * shakeRange * 2 - shakeRange;
            Vector3 cameraPosition = Vector3.zero;
            cameraPosition.x += cameraPositionX;
            cameraPosition.z += cameraPositionZ;
            _transposer.m_FollowOffset = cameraPosition;
            Invoke(nameof(CameraShakeEnd), 0.5f);
        }

        private void CameraShakeEnd()
        {
            _transposer.m_FollowOffset = _offsetDefalutPosition;
        }
    }
}