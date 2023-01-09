using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Turret
{
    public class Turret_Shot : MonoBehaviour
    {
        [SerializeField]
        private UI.JoyStick _joyStick = null;

        private Transform _firePos = null;
        private void Awake()
        {
            _firePos = GameObject.Find("FirePos").transform;
        }

        public void TurretShotting()
        {

        }
    }
}
