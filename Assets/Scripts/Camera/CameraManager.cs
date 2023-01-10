using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI:

namespace CameraManage
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField]
        private JoyStick _joyStick = null;

        public JoyStick JoyStick => _joyStick;
    }
}
