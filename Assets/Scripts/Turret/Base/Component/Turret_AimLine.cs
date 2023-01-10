using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace Turret
{
    [RequireComponent(typeof(LineRenderer))]
    public class Turret_AimLine : TurretComponent
    {
        private LineRenderer _lineRenderer = null;
        private JoyStick _joyStick = null;

        private float _range = 10f;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _joyStick = Instance.JoyStick;
            _range = Instance.TurretSO.attackRange;
        }

        private void Start()
        {
            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;

            _joyStick.AddOnPointerDownListener(OnAimStart);
            _joyStick.AddOnPointerUpListener(OnAimEnd);
        }

        private void FixedUpdate()
        {
            _lineRenderer.SetPosition(0, Instance.FirePoint.position);

            if (Physics.Raycast(Instance.FirePoint.position, Instance.FirePoint.forward, out RaycastHit hit, 100f))
            {
                _lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                _lineRenderer.SetPosition(1, Instance.FirePoint.position + Instance.FirePoint.forward * 100f);
            }
        }

        private void OnAimStart()
        {
            _lineRenderer.enabled = true;
        }

        private void OnAimEnd()
        {
            _lineRenderer.enabled = false;
        }
    }
}
