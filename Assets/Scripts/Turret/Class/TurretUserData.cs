using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;

namespace Turret
{
    public class TurretUserData
    {
        private JoyStick _attackJoyStick = null;
        public JoyStick AttackJoyStick => _attackJoyStick;

        private Image _attackImage = null;
        public Image AttackImage => _attackImage;

        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;

        public TurretUserData(JoyStick attackJoyStick, Image attackImage, AttackCancel attackCancel)
        {
            _attackJoyStick = attackJoyStick;
            _attackImage = attackImage;
            _attackCancel = attackCancel;
        }
    }
}
