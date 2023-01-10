using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Turret")]
    public class TurretSO : ScriptableObject
    {
        [Header("Rotation Speed")]
        [Range(0f, 40f)]
        public float rotationSpeed;

        [Header("Reload Speed")]
        [Range(0f, 20f)]
        public float reloadSpeed;
    }
}