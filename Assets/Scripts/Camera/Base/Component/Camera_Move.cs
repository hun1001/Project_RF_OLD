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

        private JoyStick _joyStick = null;
        private JoyStick _attackJoyStick = null;

        private void Awake()
        {
            _cmvcam = Instance.CMvcam;

            _joyStick = Instance.JoyStick;
            _attackJoyStick = Instance.AttackJoyStick;
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
    }
}