using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class TextController : MonoBehaviour
    {
        private TMP_Text _text = null;
        
        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }
        
        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
