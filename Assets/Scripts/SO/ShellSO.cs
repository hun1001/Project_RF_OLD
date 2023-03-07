using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Shell")]
    public class ShellSO : ScriptableObject
    {
        [Header("Penetrating Power")]
        public float penetratingPower;
        [Header("Base Damage")]
        public float baseDamage;
        [Header("Speed")]
        public float speed;
    }
}
