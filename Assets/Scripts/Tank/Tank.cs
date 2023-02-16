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

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;
        
        [Header("Skid")]
        [SerializeField]
        private LineRenderer[] _lineRenderer = null;
        public LineRenderer[] LineRenderer => _lineRenderer;
        
        [SerializeField]
        private Transform[] _skidMark = null;
        public Transform[] SkidMark => _skidMark;
        
        [Header("Sound")]
        public AudioClip _moveSound = null;
        public AudioClip _trackSound = null;
        public AudioClip _loadSound = null;
    }
}
