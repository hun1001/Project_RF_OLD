using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Opponent")]
    public class OpponentSO : ScriptableObject
    {
        public WaveDataSO[] Waves;
        public float[] Delay;
        public float[] DelayBetween;
    }
}
