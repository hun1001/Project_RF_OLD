using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.EventSystems;
using Cinemachine;

namespace CameraManage
{
    public class Camera_Move : CameraComponent
    {
        private CinemachineVirtualCamera _cmvcam = null;
        private CinemachineTransposer _transposer = null;

        private JoyStick _joyStick = null;
        private JoyStick _attackJoyStick = null;
        private JoyStick _snipingJoyStick = null;

        private float _offsetYDefault = 0.0f;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;
            _transposer = _cmvcam.GetCinemachineComponent<CinemachineTransposer>();

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;
            _snipingJoyStick = Instance.SnipingJoyStick;

            _offsetYDefault = _transposer.m_FollowOffset.y;
        }

        private void Update()
        {
            //CameraRotation();
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
            if(_snipingJoyStick.IsDragging == true)
            {

            }
            else if(_transposer.m_FollowOffset.y != _offsetYDefault)
            {

            }
        }
    }
}