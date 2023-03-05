using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class ControllerCanvas : BaseCanvas<GameSceneCanvases>
    {
        [Header("JoyStick")]
        [SerializeField]
        private JoyStick _moveJoyStick = null;
        public JoyStick MoveJoyStick => _moveJoyStick;

        [SerializeField]
        private JoyStick_Attack _attackJoyStick = null;
        public JoyStick_Attack AttackJoyStick => _attackJoyStick;

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
