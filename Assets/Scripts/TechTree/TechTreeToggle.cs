using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TechTree
{
    public class TechTreeToggle : MonoBehaviour
    {
        [SerializeField]
        private Toggle _toggle = null;

        [SerializeField]
        private Text _text = null;

        public void SetToggleEvent(UnityAction<bool> action) => _toggle.onValueChanged.AddListener(action);
        public void SetToggleGroup(GameObject toggleGroup) => _toggle.group = toggleGroup.GetComponent<ToggleGroup>();
        public void SetToggleName(string name) => _text.text = name;

    }
}
