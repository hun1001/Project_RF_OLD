using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shell
{
    public class ShellMove : MonoBehaviour
    {
        private float _speed = 5f;
        private int _damage = 0;

        void Update()
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime, Space.World);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }

        public void SetDamage(int damage)
        {
            _damage = damage;
        }

        public int Damage => _damage;
    }
}
