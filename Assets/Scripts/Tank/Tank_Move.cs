using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Tank
{
    public class Tank_Move : MonoBehaviour
    {
        [SerializeField]
        private JoyStick _joyStick = null;

        [SerializeField]
        private Transform _body = null;

        [SerializeField]
        private float _moveSpeed = 10f;

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