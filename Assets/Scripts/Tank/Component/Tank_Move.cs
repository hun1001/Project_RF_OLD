using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using System;

namespace Tank
{
    public class Tank_Move : Base.CustomComponent<Tank>
    {
        private JoyStick _joyStick = null;
        private Transform _body = null;

        private float _moveSpeed = 1f;
        private float _rotateSpeed = 1f;

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
                TankMoving(_joyStick.Direction, _joyStick.Scalar);
            }
        }

        protected void TankMoving(Vector2 dir, float scalar)
        {
            var dir3 = new Vector3(dir.x, 0f, dir.y);
            transform.Translate(_body.forward * dir3.magnitude * _moveSpeed * Time.deltaTime, Space.World);
            _body.rotation = Quaternion.Slerp(_body.rotation, Quaternion.LookRotation(dir3.normalized), _rotateSpeed * Time.deltaTime);
        }
    }
}