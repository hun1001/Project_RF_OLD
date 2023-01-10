using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Tank")]
    public class TankSO : ScriptableObject
    {
        [Header("Hp")]
        public float hp;

        [Header("Speed")]
        public float speed;

        [Header("Rotation Speed")]
        public float rotationSpeed;
    }
}
