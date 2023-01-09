using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tank
{
    public class Tank_Move : MonoBehaviour
    {
        [SerializeField]
        private UI.JoyStick _joyStick = null;

        private float _moveSpeed = 5f;

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
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir.normalized), _moveSpeed * Time.deltaTime);
        }
    }
}