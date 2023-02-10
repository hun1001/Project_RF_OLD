using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayCanvas : UI.Canvas
    {
        [Header("JoyStick")]
        [SerializeField]
        private JoyStick _moveJoyStick = null;
        public  JoyStick MoveJoyStick => _moveJoyStick;
        
        [SerializeField]
        private JoyStick_ClickActive _attackJoyStick = null;
        public  JoyStick_ClickActive AttackJoyStick => _attackJoyStick;
        
        [Header("Hp Bar")]
        [SerializeField]
        private Bar _hpBar = null;
        public  Bar HpBar => _hpBar;
        
        [Header("Attack")]
        [SerializeField]
        private Image _attackImage = null;
        public Image AttackImage => _attackImage;
        
        [SerializeField]
        private AttackCancel _attackCancel = null;
        public AttackCancel AttackCancel => _attackCancel;

        [Header("Result")]
        [SerializeField]
        private GameObject _resultPanel = null;
        public GameObject ResultPanel => _resultPanel;

        [SerializeField]
        private Button _mainButton = null;
        public Button MainButton => _mainButton;

        [SerializeField]
        private Button _restartButton = null;
        public Button RestartButton => _restartButton;
    }
}
