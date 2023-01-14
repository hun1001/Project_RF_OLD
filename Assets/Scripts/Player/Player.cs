using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace Player
{
    public class Player : Base.CustomGameObject
    {
        [Header("Body Parts")]
        [SerializeField]
        private JoyStick _moveJoyStick = null;
        public JoyStick MoveJoyStick => _moveJoyStick;

        [SerializeField]
        private Bar _hpBar = null;
        public Bar HpBar => _hpBar;

        [Header("Turret Parts")]
        [SerializeField]
        private JoyStick _attackJoyStick = null;
        public JoyStick AttackJoyStick => _attackJoyStick;

        [SerializeField]
        private Image _attackImage = null;
        public Image AttackImage => _attackImage;

        [SerializeField]
        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;
    }
}
