using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.AI;

namespace Tank
{
    public class Tank_Move : Base.CustomComponent<Tank>
    {
        private JoyStick _joyStick = null;
        private Transform _body = null;
        private Rigidbody _rigidbody = null;
        private NavMeshAgent _navMeshAgent = null;

        private float _maxSpeed = 1f;
        private float _rotateSpeed = 1f;
        private float _acceleration = 1f;

        protected override void Assignment()
        {
            _joyStick = Instance.JoyStick;
            _body = Instance.Body;
            _rigidbody = GetComponent<Rigidbody>();

            _maxSpeed = Instance.TankSO.maxSpeed;
            _rotateSpeed = Instance.TankSO.rotationSpeed;
            _acceleration = Instance.TankSO.acceleration;
            
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _navMeshAgent.acceleration = _acceleration;
            _navMeshAgent.speed = _maxSpeed;
            _navMeshAgent.angularSpeed = _rotateSpeed;
        }

        protected virtual void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                TankMoving(_joyStick.Direction, _joyStick.Scalar);
            }
        }

        private void TankMoving(Vector2 dir, float scalar)
        {
            if(dir != Vector2.zero)
            {
                Vector3 dir3 = new Vector3(dir.x, 0, dir.y);
                
            }
            else
            {
                
            }
        }
    }
}