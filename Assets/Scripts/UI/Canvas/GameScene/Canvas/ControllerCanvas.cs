using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class ControllerCanvas : UI.BaseCanvas
    {
        [Header("JoyStick")]
        [SerializeField]
        private JoyStick _moveJoyStick = null;
        public  JoyStick MoveJoyStick => _moveJoyStick;
        
        [SerializeField]
        private JoyStick_ClickActive _attackJoyStick = null;
        public JoyStick_ClickActive AttackJoyStick => _attackJoyStick;
        
        [SerializeField]
        private Button[] _skillButtons = null;
        public Button[] SkillButtons => _skillButtons;
        
        protected override void SetOnEnableAction()
        {
            
        }
        
        protected override void SetOnDisableAction()
        {
            
        }
    }
}
