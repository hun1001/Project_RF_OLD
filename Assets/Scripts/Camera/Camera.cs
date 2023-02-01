using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Cinemachine;

namespace CameraManage
{
    public partial class Camera : Base.CustomGameObject
    {
        [SerializeField]
        private JoyStick _joyStick = null;
        [SerializeField]
        private JoyStick _attackJoyStick = null;
        [SerializeField]
        private JoyStick _snipingJoyStick = null;
        [SerializeField]
        private CinemachineVirtualCamera _cmvcam = null;

        public JoyStick JoyStick => _joyStick;
        public JoyStick AttackJoyStick => _attackJoyStick;
        public JoyStick SnipingJoyStick => _snipingJoyStick;
        public CinemachineVirtualCamera CMvcam => _cmvcam;
    }
}
