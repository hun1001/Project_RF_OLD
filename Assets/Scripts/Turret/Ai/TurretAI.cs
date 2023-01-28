using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class TurretAI : MonoBehaviour
    {
        [SerializeField] 
        private Transform _turret = null;
        
        private Transform _target = null;
        
        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;
        }

        private void Update()
        {
            LookTarget();
        }

        private void LookTarget()
        {
            if (_target is null)
            {
                return;
            }
            
            Vector2 direction = _target.position - _turret.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _turret.rotation = Quaternion.Slerp(_turret.rotation, rotation, 1);
        }
    }
}
