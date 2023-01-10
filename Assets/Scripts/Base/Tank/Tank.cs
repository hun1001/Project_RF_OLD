using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank : MonoBehaviour
    {
        [Header("Controller")]
        [SerializeField]
        private JoyStick _moveJoyStick = null;

        [SerializeField]
        private JoyStick _attackJoyStick = null;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;

        public JoyStick MoveJoyStick => _moveJoyStick;
        public JoyStick AttackJoyStick => _attackJoyStick;
        public Transform Body => _body;
    }
}
