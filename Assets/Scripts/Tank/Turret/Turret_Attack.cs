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

        [SerializeField]
        private LineRenderer _lineRenderer = null;

        private float _nextFire = 0f;

        void Awake()
        {
            _joyStick.AddOnStartDragListener(DrawStartAimLine);
            _joyStick.AddOnEndDragListener(Fire);
            _joyStick.AddOnEndDragListener(DrawEndAimLine);

            _lineRenderer.positionCount = 2;
            _lineRenderer.enabled = false;
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

            }
        }

        private void DrawStartAimLine()
        {
            _lineRenderer.enabled = true;
        }

        private void DrawEndAimLine()
        {
            _lineRenderer.enabled = false;
        }

        private void Update()
        {
            if (_nextFire > 0)
            {
                _nextFire -= Time.deltaTime;
            }

            _lineRenderer.SetPosition(0, _firePoint.position);
            _lineRenderer.SetPosition(1, _firePoint.position + _firePoint.forward * 100f);

            _fireImage.fillAmount = 1f - _nextFire / _fireRate;
        }
    }
}
