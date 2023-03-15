using UnityEngine;

namespace Turret
{
    public class TurretAI : MonoBehaviour
    {
        [SerializeField]
        private Transform _turret = null;

        private Transform _target = null;

        private void Start()
        {
            _target = GameObject.FindGameObjectWithTag("PlayerTank").transform;
        }

        private void Update()
        {
            LookTarget();
        }

        private void LookTarget()
        {
            if (_target is null)
            {
                return;
            }

            Vector3 direction = _target.position - _turret.position;
            // float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
            // Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
            // _turret.rotation = Quaternion.Slerp(_turret.rotation, rotation, 1);
            _turret.rotation = Quaternion.RotateTowards(_turret.rotation, Quaternion.LookRotation(direction.normalized), 180 * Time.deltaTime);

        }
    }
}
