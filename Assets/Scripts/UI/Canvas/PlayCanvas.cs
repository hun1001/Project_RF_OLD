using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayCanvas : UI.Canvas
    {
        [SerializeField]
        private JoyStick _moveJoyStick = null;
        public  JoyStick MoveJoyStick => _moveJoyStick;
        
        [SerializeField]
        private JoyStick_ClickActive _attackJoyStick = null;
        public  JoyStick_ClickActive AttackJoyStick => _attackJoyStick;
        
        [SerializeField]
        private Bar _hpBar = null;
        public  Bar HpBar => _hpBar;
        
        [SerializeField]
        private Image _attackImage = null;
        public Image AttackImage => _attackImage;
        
        [SerializeField]
        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;
    }
}
