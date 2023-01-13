using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;

namespace Turret
{
    public class Turret : Base.CustomGameObject
    {
        [Header("Data")]
        [SerializeField]
        private SO.TurretSO _turretSO = null;
        public SO.TurretSO TurretSO => _turretSO;

        [Header("UI/UX")]
        [SerializeField]
        private Image _image = null;
        public Image Image => _image;

        [SerializeField]
        private JoyStick _joyStick = null;
        public JoyStick JoyStick => _joyStick;

        [SerializeField]
        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;

        [SerializeField]
        private Transform _firePoint = null;
        public Transform FirePoint => _firePoint;

        public void Assignment(TurretUserData turretUserData)
        {
            _image = turretUserData.AttackImage;
            _joyStick = turretUserData.AttackJoyStick;
            _attackCancel = turretUserData.AttackCancel;
            base.Initialize();
        }
    }
}
