using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class PlayInformationCanvas : MonoBehaviour
    {
        [SerializeField]
        private Bar _hpBar = null;
        public Bar HpBar => _hpBar;
        
        [SerializeField]
        private WaveTimer _waveTimer = null;
        public WaveTimer WaveTimer => _waveTimer;
        
        [SerializeField]
        private TextController _goldText = null;
        public TextController GoldText => _goldText;
    }
}
