using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Turret
{
    public class Turret_Rotate : TurretComponent
    {
        private JoyStick _joyStick;
        private Transform _turret = null;

        private float _rotationSpeed = 1f;

        private bool _isAim = false;

        private void Awake()
        {
            _joyStick = Instance.JoyStick;
            _turret = Instance.Body;

            _rotationSpeed = Instance.TurretSO.rotationSpeed;
        }

        private void Update()
        {
            if (_joyStick.Direction != Vector2.zero)
            {
                Rotate();
            }
            else
            {
                StartCoroutine(nameof(Release));
            }
        }

        private void Rotate()
        {
            Vector3 dir = Vector3.zero;
            dir.x = _joyStick.Horizontal;
            dir.z = _joyStick.Vertical;

            _isAim = true;
            StopCoroutine(nameof(Release));

            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(dir.normalized), 180 * Time.deltaTime * _rotationSpeed);
        }

        private IEnumerator Release()
        {
            if (_isAim == false)
            {
                yield break;
            }
            _isAim = false;

            yield return new WaitForSeconds(3f);

            while (true)
            {
                if (Mathf.Abs(_turret.eulerAngles.y) < 0.1f)
                {
                    _turret.eulerAngles = Vector3.zero;
                    break;
                }

                if (_isAim == true)
                {
                    break;
                }

                _turret.localRotation = Quaternion.RotateTowards(_turret.localRotation, Quaternion.LookRotation(Vector3.zero), 180 * Time.deltaTime / _rotationSpeed / 2);
                yield return null;
            }
        }
    }
}
