using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Turret
{
    public class Turret_Rotation : Base.CustomComponent<Turret>
    {
        private Transform _turret = null;

        private float _rotationSpeed = 1f;

        private bool _isAim = false;

        Vector3 _dir = Vector3.zero;

        protected void Awake()
        {
            _turret = Instance.Body;
            _rotationSpeed = Instance.TurretSO.rotationSpeed;
        }

        public virtual void Rotate(JoyStick attackJoyStick)
        {
            if (attackJoyStick.Direction != Vector2.zero)
            {
                _dir.x = attackJoyStick.Horizontal;
                _dir.z = attackJoyStick.Vertical;
            }
            
            _isAim = true;
            StopCoroutine(nameof(Release));

            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(_dir.normalized), 180 * Time.deltaTime * _rotationSpeed);
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
