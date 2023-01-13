using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace CameraManage
{
    public partial class Camera : Base.CustomGameObject
    {
        [SerializeField]
        private JoyStick _joyStick = null;

        public JoyStick JoyStick => _joyStick;
    }
}
