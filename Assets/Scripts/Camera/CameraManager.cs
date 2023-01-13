using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Cinemachine;

namespace CameraManage
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField]
        private JoyStick _joyStick = null;
        [SerializeField]
        private JoyStick _attackJoyStick = null;
        [SerializeField]
        private CinemachineVirtualCamera _cmvcam;

        public JoyStick JoyStick => _joyStick;
        public JoyStick AttackJoyStick => _attackJoyStick;
        public CinemachineVirtualCamera CMvcam => _cmvcam;
    }
}
