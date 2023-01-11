using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class TypeReader
    {
        public static HitType GetHitType(float angle) => angle switch
        {
            < 30f => HitType.RICOCHET,
            _ => HitType.PENETRATION
        };

        public static HitType GetHitType(Vector3 incoming, Vector3 normal) => GetHitType(Vector3Calculator.GetIncomingAngle(incoming, normal));
    }
}
