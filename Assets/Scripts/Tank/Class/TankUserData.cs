using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;

namespace Tank
{
    [System.Serializable]
    public class TankUserData
    {
        private JoyStick _moveJoyStick = null;
        public JoyStick MoveJoyStick => _moveJoyStick;

        private Bar _hpBar = null;
        public Bar HpBar => _hpBar;

        public TankUserData(JoyStick moveJoyStick, Bar hpBar)
        {
            _moveJoyStick = moveJoyStick;
            _hpBar = hpBar;
        }
    }
}
