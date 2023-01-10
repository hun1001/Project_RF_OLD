using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Turret")]
    public class TurretSO : ScriptableObject
    {
        [Header("Rotation Speed")]
        public float rotationSpeed;

        [Header("Reload Speed")]
        public float reloadSpeed;

        [Header("Attack Range")]
        public float attackRange;
    }
}