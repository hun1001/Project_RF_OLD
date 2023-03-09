using UnityEngine;
using UnityEngine.UI;
using UI;

namespace TechTree
{
    public class TechTreeNode : MonoBehaviour
    {
        [SerializeField]
        private TextController _textController = null;

        public void SetNode(string text)
        {
            //_textController.SetText(text);
            transform.localScale = Vector3.one;
        }

        public void SetNodeImage(Sprite sprite) => transform.GetChild(0).GetComponent<Image>().sprite = sprite;

    }
}
