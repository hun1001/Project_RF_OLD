using UnityEngine;

namespace Turret
{
    [RequireComponent(typeof(LineRenderer))]
    public class Turret_AimLine : Base.CustomComponent<Turret>
    {
        // TODO: 라인 렌더러 별개의 오브젝트로 분리해서 차라리 라인 렌더러 매니저 만들어서 하느거 고민해보기
        private LineRenderer _lineRenderer = null;

        private float _range = 50f;

        protected void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();

            //_range = Instance.TurretSO.attackRange;

            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            _lineRenderer.SetPosition(0, Instance.FirePoint.position);

            if (Physics.Raycast(Instance.FirePoint.position, Instance.FirePoint.forward, out RaycastHit hit, _range) && hit.transform.CompareTag("OpponentTank"))
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

        public void OnAimStart()
        {
            _lineRenderer.enabled = true;
        }

        public void OnAimEnd()
        {
            _lineRenderer.enabled = false;
        }
    }
}
