using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private SO.TankSO _tankSO = null;

        [Header("Controller")]
        [SerializeField]
        private JoyStick _joyStick = null;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;

        public JoyStick JoyStick => _joyStick;
        public Transform Body => _body;
    }
}
