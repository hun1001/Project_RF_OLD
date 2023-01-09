using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Hp : MonoBehaviour
    {
        [SerializeField]
        private int _hp = 1000;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Shell"))
            {
                _hp -= collision.gameObject.GetComponent<Shell.ShellMove>().Damage;
            }
        }

        public int Hp => _hp;
    }
}
