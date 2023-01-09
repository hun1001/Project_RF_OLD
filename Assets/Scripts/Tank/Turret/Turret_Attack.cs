using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using Tank;

namespace Turret
{
    public class Turret_Attack : MonoBehaviour
    {
        [SerializeField]
        private Transform _firePoint = null;

        [SerializeField]
        private JoyStick _joyStick = null;

        [SerializeField]
        private Image _fireImage = null;

        [SerializeField]
        private float _fireRate = 1f;

        private float _nextFire = 0f;

        void Awake()
        {
            _joyStick.AddOnEndDragListener(Fire);
        }

        private void Fire()
        {
            if (_nextFire > 0)
            {
                return;
            }

            _nextFire = _fireRate;

            RaycastHit hit = default;

            if (Physics.Raycast(_firePoint.position, _firePoint.forward, out hit, 100f))
            {
                Debug.Log(hit.transform.name);
                Debug.Log(hit.point);
                Debug.Log(hit.normal);
            }
        }

        private void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }

            _fireImage.fillAmount = 1f - _nextFire / _fireRate;
        }
    }
}
