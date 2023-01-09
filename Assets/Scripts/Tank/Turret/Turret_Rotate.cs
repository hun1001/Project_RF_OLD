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
        private Transform _parent = null;
        private Vector3 _direction = Vector3.zero;
        
        private Turret_Shot _shot = null;
        private WaitForSeconds _comebackSecond = new WaitForSeconds(0f);
        private bool _isShot = false;

        private void Awake()
        {
            _parent = transform.parent;
            _shot = GetComponent<Turret_Shot>();
        }

        private void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                TurretRotation();
            }
            else if(_isShot)
            {
                _isShot = false;
                _shot.TurretShotting();
            }
        }

        private void TurretRotation()
        {
            _direction.x = _joyStick.Horizontal;
            _direction.z = _joyStick.Vertical;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_direction.normalized), _rotateSpeed * Time.deltaTime);
            _isShot = true;
        }

        public IEnumerator TurretComeback()
        {
            while(transform.rotation != _parent.rotation)
            {
                if (_isShot == true) yield break;
                transform.rotation = Quaternion.Slerp(transform.rotation, _parent.rotation, _rotateSpeed * Time.deltaTime);
                yield return _comebackSecond;
            }
        }

        public Vector3 Direction => _direction;
    }
}
