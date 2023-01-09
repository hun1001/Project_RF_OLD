using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Turret
{
    public class Turret_Rotate : MonoBehaviour
    {
        [SerializeField]
        private JoyStick _joyStick;

        [SerializeField]
        private Transform _turret = null;

        private bool _isAim = false;

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

            _turret.rotation = Quaternion.Slerp(_turret.rotation, Quaternion.LookRotation(dir.normalized), 10f * Time.deltaTime);
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

                _turret.eulerAngles = Vector3.Lerp(_turret.eulerAngles, Vector3.zero, 10f * Time.deltaTime);
                yield return null;
            }
        }
    }
}
