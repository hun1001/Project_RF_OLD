﻿using System.Collections;
using System.Collections.Generic;
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

        private Vector3 _beforeDirection = Vector3.zero;

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
            
            float beforeAngle = Vector3.Angle(_beforeDirection, Instance.transform.forward);
            float currentAngle = Vector3.Angle(new Vector3(_joyStick.Horizontal, 0f, _joyStick.Vertical), Instance.transform.forward);
            
            Debug.Log(beforeAngle - currentAngle);

            if (new Vector3(_joyStick.Horizontal, 0f, _joyStick.Vertical) + _beforeDirection != Vector3.zero)
            {
                if (NavMesh.SamplePosition(transform.position + Instance.transform.forward * _currentSpeed * Time.deltaTime, out NavMeshHit hit, 0.5f, NavMesh.AllAreas))
                {
                    _rigidbody.velocity = Instance.transform.forward * _currentSpeed;
                }
                else
                {
                    _rigidbody.velocity = Vector3.zero;
                }
            }
            else
            {
                if (NavMesh.SamplePosition(transform.position + (-Instance.transform.forward * _currentSpeed * Time.deltaTime), out NavMeshHit hit, 0.5f, NavMesh.AllAreas))
                {
                    _rigidbody.velocity = -Instance.transform.forward * _currentSpeed;
                }
                else
                {
                    _rigidbody.velocity = Vector3.zero;
                }
            }

            if (_joyStick.IsTouching)
            {
                Vector3 direction = new Vector3(_joyStick.Horizontal, 0f, _joyStick.Vertical);
                direction.y = 0f;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Instance.transform.rotation = Quaternion.Slerp(Instance.transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
                _beforeDirection = direction;
            }
        }
    }
}
