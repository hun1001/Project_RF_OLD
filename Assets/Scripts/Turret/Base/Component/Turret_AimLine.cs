using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Util;

namespace Turret
{
    [RequireComponent(typeof(LineRenderer))]
    public class Turret_AimLine : Base.CustomComponent<Turret>
    {
        private LineRenderer _lineRenderer = null;
        private JoyStick _joyStick = null;

        private float _range = 50f;

        protected override void Assignment()
        {
            base.Assignment();
            _lineRenderer = GetComponent<LineRenderer>();
            _joyStick = Instance.JoyStick;
            //_range = Instance.TurretSO.attackRange;

            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;

            _joyStick.AddOnPointerDownListener(OnAimStart);
            _joyStick.AddOnPointerUpListener(OnAimEnd);
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, Instance.FirePoint.position);

            if (Physics.Raycast(Instance.FirePoint.position, Instance.FirePoint.forward, out RaycastHit hit, _range)&& hit.transform.CompareTag("OpponentTank"))
            {
                _lineRenderer.SetPosition(1, hit.point);
                _lineRenderer.startColor = Color.green;
                _lineRenderer.endColor = Color.green;

                hit.transform.SendMessage("Aiming", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                _lineRenderer.startColor = Color.red;
                _lineRenderer.endColor = Color.red;
                _lineRenderer.SetPosition(1, Instance.FirePoint.position + Instance.FirePoint.forward * _range);
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
