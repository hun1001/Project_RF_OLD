using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Tank")]
    public class TankSO : ScriptableObject
    {
        [Header("Hp")]
        [Range(0f, 10000f)]
        public float hp;
        [Header("Speed")]
        [Range(0f, 10f)]
        public float speed;
        [Header("Reload Speed")]
        [Range(0f, 20f)]
        public float reloadSpeed;
    }
}