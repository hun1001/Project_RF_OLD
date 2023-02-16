using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Turret
{
    public class Turret_Rotation : Base.CustomComponent<Turret>
    {
        protected Transform _turret = null;

        protected float _rotationSpeed = 1f;

        public bool _isAim = false;

        protected void Assignment()
        {
            _turret = Instance.Body;

            _rotationSpeed = Instance.TurretSO.rotationSpeed;
        }

        public virtual void Rotate(JoyStick attackJoyStick)
        {
            Vector3 dir = Vector3.zero;
            if(attackJoyStick.Direction != Vector2.zero)
            {
                dir.x = attackJoyStick.Horizontal;
                dir.z = attackJoyStick.Vertical;
            }

            _isAim = true;
            StopCoroutine(nameof(Release));

            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(dir.normalized), 180 * Time.deltaTime * _rotationSpeed);
        }

        public IEnumerator Release()
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
