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

        private float _attackRange = 0.0f;

        private float _offsetYDefault = 0.0f;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;
            _snipingJoyStick = Instance.SnipingJoyStick;
            _attackRange = GameObject.FindGameObjectWithTag("PlayerTank").GetComponent<Turret_Attack>().Range;

            _offsetYDefault = _transposer.m_FollowOffset.y;
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
                Vector3 offset = Vector3.zero;
                float yPos = _offsetYDefault * (_attackRange / 40f);
                if (yPos < _offsetYDefault) yPos = _offsetYDefault;
                offset.y = yPos;

                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
            }
            else if(_transposer.m_FollowOffset.y != _offsetYDefault)
            {
                Vector3 offset = Vector3.zero;
                offset.y = _offsetYDefault;

                _transposer.m_FollowOffset = Vector3.Slerp(_transposer.m_FollowOffset, offset, 2f * Time.deltaTime);
            }
        }
    }
}