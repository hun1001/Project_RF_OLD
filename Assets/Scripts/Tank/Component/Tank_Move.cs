using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UI;
using UnityEngine.AI;

namespace Tank
{
    public class Tank_Move : Base.CustomComponent<Tank>
    {
        private Rigidbody _rigidbody = null;
        private JoyStick _joyStick = null;

        private float _currentSpeed = 0f;
        private float _maxSpeed = 0f;

        private float _acceleration = 0f;

        private float _rotationSpeed = 0f;
        
        private int _currentSkidMark = 0;

        protected override void Assignment()
        {
            _rigidbody = Instance.GetComponent<Rigidbody>();
            _joyStick = Instance.JoyStick;

            _maxSpeed = Instance.TankSO.maxSpeed;
            _acceleration = Instance.TankSO.acceleration;
            _rotationSpeed = Instance.TankSO.rotationSpeed;

            _currentSpeed = 0f;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (_joyStick.IsTouching)
            {
                _currentSpeed += _acceleration * Time.deltaTime;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);
            }
            else
            {
                _currentSpeed -= _acceleration * Time.deltaTime;
                _currentSpeed = Mathf.Clamp(_currentSpeed, 0f, _maxSpeed);
            }
            
            if (NavMesh.SamplePosition(transform.position + Instance.transform.forward * _currentSpeed * Time.deltaTime, out NavMeshHit hit, 0.5f, NavMesh.AllAreas))
            {
                _rigidbody.velocity = Instance.transform.forward * _currentSpeed;
                Instance.LineRenderer[0].positionCount = _currentSkidMark + 1;
                Instance.LineRenderer[1].positionCount = _currentSkidMark + 1;
                Instance.LineRenderer[0].SetPosition(_currentSkidMark, Instance.SkidMark[0].position + new Vector3(0,0.1f,0));
                Instance.LineRenderer[1].SetPosition(_currentSkidMark++, Instance.SkidMark[1].position + new Vector3(0, 0.1f, 0));
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }

            if (_joyStick.IsTouching)
            {
                Vector3 direction = new Vector3(_joyStick.Horizontal, 0f, _joyStick.Vertical);
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}
