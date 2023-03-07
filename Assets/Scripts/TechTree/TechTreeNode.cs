using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace TechTree
{
    public class TechTreeNode : MonoBehaviour
    {
        [SerializeField]
        private TextController _textController = null;

        public void SetNode(string text)
        {
            //(transform as RectTransform).localScale = Vector3.one;
            _textController.SetText(text);
        }
    }
}
