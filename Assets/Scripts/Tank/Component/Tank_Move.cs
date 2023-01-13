using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using System;

namespace Tank
{
    public class Tank_Move : TankComponent
    {
        private JoyStick _joyStick = null;
        protected Transform _body = null;

        protected float _moveSpeed = 1f;
        protected float _rotateSpeed = 1f;

        protected override void Assignment()
        {
            base.Assignment();
            _joyStick = Instance.JoyStick;
            _body = Instance.Body;

            _moveSpeed = Instance.TankSO.speed;
            _rotateSpeed = Instance.TankSO.rotationSpeed;
        }

        protected virtual void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                TankMoving();
            }
        }

        protected virtual void TankMoving()
        {
            Vector3 dir = Vector3.zero;
            dir.x = _joyStick.Horizontal;
            dir.z = _joyStick.Vertical;

            transform.Translate(_body.forward * dir.magnitude * _moveSpeed * Time.deltaTime, Space.World);
            _body.rotation = Quaternion.Slerp(_body.rotation, Quaternion.LookRotation(dir.normalized), _rotateSpeed * Time.deltaTime);
        }
    }
}