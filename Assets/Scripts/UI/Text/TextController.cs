using TMPro;
using UnityEngine;

namespace UI
{
    public class TextController : MonoBehaviour
    {
        private TMP_Text _text = null;

        private void Awake()
        {
            TryGetComponent(out _text);
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
