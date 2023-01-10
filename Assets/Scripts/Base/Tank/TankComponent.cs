using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public abstract class TankComponent : MonoBehaviour
    {
        private Tank _tank = null;

        public Tank Tank
        {
            get
            {
                if (_tank == null)
                {
                    _tank = GetComponentInParent<Tank>();
                }

                return _tank;
            }
        }

    }
}
