using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class TurretAI_Rotate : Turret_Rotate
    {
        private TurretAI_Attack _turret_Attack;
        private Transform _player = null;

        private float _attackRange = 10f;

        private void Start()
        {
            Debug.Log("TurretAI_Rotate Start");
            // Null
        }

        protected override void Update()
        {
            if (Vector3.Distance(transform.position, _player.position) <= _attackRange)
            {
                Rotate();
            }
            else
            {
                StartCoroutine(nameof(Release));
            }
        }

        protected override void Rotate()
        {
            Vector3 dir = _player.position - transform.position;
            dir.y = 0.0f;

            _isAim = true;
            StopCoroutine(nameof(Release));

            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(dir.normalized), 180 * Time.deltaTime * _rotationSpeed);
        }
    }
}
