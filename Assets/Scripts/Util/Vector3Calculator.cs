using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public static class Vector3Calculator
    {
        public static Vector3 GetReflectionVector(Vector3 incomingVector, Vector3 normalVector)
        {
            return Vector3.Reflect(incomingVector.normalized, normalVector.normalized).normalized;
        }

        public static float GetIncomingAngle(Vector3 incomingVector, Vector3 normalVector)
        {
            float angle = Vector3.Angle(incomingVector, normalVector);
            angle = angle < 0 ? angle * -1 : angle;
            angle = angle > 90 ? angle % 90 : angle;
            angle = (int)angle == 0 ? 90 : angle;

            return angle;
        }
    }
}
