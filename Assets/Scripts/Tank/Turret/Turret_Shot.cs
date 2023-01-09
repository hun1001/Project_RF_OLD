using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class Turret_Shot : MonoBehaviour
    {
        [SerializeField]
        private UI.JoyStick _joyStick = null;
        [SerializeField]
        private GameObject _shellPrefab = null;

        private Turret_Rotate _rotate = null;
        private Transform _firePos = null;
        private float _shotCooldown = 3f;
        private float _shotCurrentCooldown = 0f;

        private void Awake()
        {
            _firePos = GameObject.Find("FirePos").transform;
            _rotate = GetComponent<Turret_Rotate>();
        }

        private void Update()
        {
            if(_shotCurrentCooldown > 0f)
            {
                _shotCurrentCooldown -= Time.deltaTime;
                if (_shotCurrentCooldown < 0f) _shotCurrentCooldown = 0f;
            }
        }

        public void TurretShotting()
        {
            if (_shotCurrentCooldown != 0f)
            {
                TurretComebackStart();
                return;
            }
            _shotCurrentCooldown = _shotCooldown;

            Instantiate(_shellPrefab, _firePos.position, transform.rotation);

            Invoke("TurretComebackStart", 1f);
        }

        private void TurretComebackStart()
        {
            StartCoroutine(_rotate.TurretComeback());
        }
    }
}
