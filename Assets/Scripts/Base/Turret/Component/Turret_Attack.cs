using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using Util;

namespace Turret
{
    public class Turret_Attack : TurretComponent
    {
        private Transform _firePoint = null;
        private JoyStick _joyStick = null;
        private Image _fireImage = null;
        private LineRenderer _lineRenderer = null;

        private float _fireRate = 1f;

        private float _nextFire = 0f;

        private void Awake()
        {
            _firePoint = Instance.FirePoint;
            _joyStick = Instance.JoyStick;
            _fireImage = Instance.Image;
            _lineRenderer = Instance.LineRenderer;

            _fireRate = Instance.TurretSO.reloadSpeed;
        }

        private void Start()
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
                PoolManager.Instance.Get("Assets/Resource/Effect/WFX_ExplosiveSmoke.prefab", hit.point);
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
