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
        private Image _attackImage = null;
        public Image AttackImage => _attackImage;

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
        
        public AudioClip _fireSound = null;

        // public void Assignment(TurretUserData turretUserData)
        // {
        //     _attackImage = turretUserData.AttackImage;
        //     _joyStick = turretUserData.AttackJoyStick;
        //     _attackCancel = turretUserData.AttackCancel;
        //     base.Initialize();
        // }
    }
}
