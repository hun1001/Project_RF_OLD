using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO;

namespace Tank
{
    public class TankAI_Move : Tank_Move
    {
        [SerializeField]
        private TurretSO _turretSO = null;

        private Transform _player = null;

        private float _attackRange = 10f;

        protected override void Awake()
        {
            base.Awake();

            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _attackRange = _turretSO.attackRange;
        }

        protected override void Update()
        {
            if(Vector3.Distance(transform.position, _player.position) > _attackRange)
            {
                TankMoving();
            }
        }

        protected override void TankMoving()
        {
            Vector3 dir = _player.position - transform.position;
            dir.y = 0.0f;
            dir.Normalize();

            transform.Translate(_body.forward * dir.magnitude * _moveSpeed * Time.deltaTime, Space.World);
            _body.rotation = Quaternion.Slerp(_body.rotation, Quaternion.LookRotation(dir.normalized), _rotateSpeed * Time.deltaTime);
        }
    }
}
