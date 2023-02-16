using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;

namespace Turret
{
    public class Turret : Base.CustomGameObject
    {
        [Header("Data")]
        [SerializeField]
        private SO.TurretSO _turretSO = null;
        public SO.TurretSO TurretSO => _turretSO;

        [Header("Transform")]
        [SerializeField]
        private Transform _body = null;
        public Transform Body => _body;

        [SerializeField]
        private Transform _firePoint = null;
        public Transform FirePoint => _firePoint;
        
        [Header("Sound")]
        public AudioClip _fireSound = null;
        public AudioClip _reloadSound = null;
        public AudioClip _shellDropSound = null;
        
        
    }
}
