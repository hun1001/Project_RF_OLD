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
        public SO.TankSO TankSO => _tankSO;

        [Header("UI")]
        [SerializeField]
        private JoyStick _joyStick = null;

        [Header("UX")]
        [SerializeField]
        private Bar _healthBar = null;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;


        public JoyStick JoyStick => _joyStick;
        public Bar HealthBar => _healthBar;
        public Transform Body => _body;
    }
}
