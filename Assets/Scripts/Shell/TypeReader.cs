using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class TypeReader : Singleton<TypeReader>
    {
        private float _ricochetAngle = 30f;
        public float RicochetAngle
        {
            get
            {
                return _ricochetAngle;
            }
            set
            {
                _ricochetAngle = value;
            }
        }

        public HitType GetHitType(float angle)
        {
            if (angle < _ricochetAngle) return HitType.RICOCHET;
            else return HitType.PENETRATION;
        }

        public HitType GetHitType(Vector3 incoming, Vector3 normal) => GetHitType(Vector3Calculator.GetIncomingAngle(incoming, normal));
    }
}
