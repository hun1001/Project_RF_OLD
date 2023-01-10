using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;

namespace Turret
{
    public class Turret : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField]
        private SO.TurretSO _turretSO = null;
        public SO.TurretSO TurretSO => _turretSO;

        [Header("Controller")]

        [SerializeField]
        private Image _image = null;

        [SerializeField]
        private JoyStick _joyStick = null;

        [Header("Transform")]

        [SerializeField]
        private Transform _body = null;

        [SerializeField]
        private Transform _firePoint = null;

        public Image Image => _image;
        public JoyStick JoyStick => _joyStick;
        public Transform Body => _body;
        public Transform FirePoint => _firePoint;
    }
}
