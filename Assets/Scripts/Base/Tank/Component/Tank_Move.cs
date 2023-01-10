using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_Move : TankComponent
    {
        private JoyStick _joyStick = null;
        private Transform _body = null;

        private float _moveSpeed = 10f;

        private void Awake()
        {
            _joyStick = Instance.JoyStick;
            _body = Instance.Body;
        }

        private void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                TankMoving();
            }
        }

        private void TankMoving()
        {
            Vector3 dir = Vector3.zero;
            dir.x = _joyStick.Horizontal;
            dir.z = _joyStick.Vertical;

            transform.Translate(dir * _moveSpeed * Time.deltaTime, Space.World);
            _body.rotation = Quaternion.Slerp(_body.rotation, Quaternion.LookRotation(dir.normalized), _moveSpeed * Time.deltaTime);
        }
    }
}