using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace Player
{
    public class Player : Base.CustomGameObject
    {
        #region Body Parts

        private JoyStick _moveJoyStick = null;
        public JoyStick MoveJoyStick => _moveJoyStick;

        private Bar _hpBar = null;
        public Bar HpBar => _hpBar;

        #endregion

        #region Turret Parts
        
        private JoyStick _attackJoyStick = null;
        public JoyStick AttackJoyStick => _attackJoyStick;

        private Image _attackImage = null;
        public Image AttackImage => _attackImage;

        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;
        
        #endregion

        private void Awake()
        {
            PlayCanvas playCanvas = FindObjectOfType<PlayCanvas>();
            
            _moveJoyStick = playCanvas.MoveJoyStick;
            _hpBar = playCanvas.HpBar;
            _attackJoyStick = playCanvas.AttackJoyStick;
            _attackImage = playCanvas.AttackImage;
            _attackCancel = playCanvas.AttackCancel;

            base.Initialize();
        }
    }
}
