using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class Turret_Rotate : MonoBehaviour
    {
        [SerializeField]
        private UI.JoyStick _joyStick;

        private float _rotateSpeed = 1f;
        private Transform _parent;

        private void Awake()
        {
            _parent = transform.parent;
        }

        private void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                TurretRotation();
            }
            else if (transform.rotation != _parent.rotation)
            {
                TurretComeback();
            }
        }

        private void TurretRotation()
        {
            Vector3 dir = Vector3.zero;
            dir.x = _joyStick.Horizontal;
            dir.z = _joyStick.Vertical;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir.normalized), _rotateSpeed * Time.deltaTime);
        }

        private void TurretComeback()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _parent.rotation, _rotateSpeed * Time.deltaTime);
        }
    }
}
