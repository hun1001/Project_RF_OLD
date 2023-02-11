using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank : Base.CustomGameObject
    {
        [Header("Data")]
        [SerializeField]
        private SO.TankSO _tankSO = null;
        public SO.TankSO TankSO => _tankSO;

        [Header("UI/UX")]
        [SerializeField]
        private JoyStick _joyStick = null;
        public JoyStick JoyStick => _joyStick;

        [SerializeField]
        private Bar _healthBar = null;
        public Bar HealthBar => _healthBar;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;
        
        //0: left 1: right
        [Header("Skid")]
        [SerializeField]
        private LineRenderer[] _lineRenderer = null;
        public LineRenderer[] LineRenderer => _lineRenderer;
        
        [SerializeField]
        private Transform[] _skidMark = null;
        public Transform[] SkidMark => _skidMark;
        
        [Header("Sound")]
        public AudioClip _moveSound = null;

        // public void Assignment(TankUserData tankUserData)
        // {
        //     _joyStick = tankUserData.MoveJoyStick;
        //     _healthBar = tankUserData.HpBar;
        //     base.Initialize();
        // }
    }
}
