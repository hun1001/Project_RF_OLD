using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class WaveTimer : MonoBehaviour
    {
        private TextMeshProUGUI _timerText;

        private void Awake()
        {
            _timerText = GetComponent<TextMeshProUGUI>();
        }

        public void SetTimer(float timer)
        {
            _timerText.text = string.Format("Next Wave\n{0:0.0}", timer);
        }
    }
}
