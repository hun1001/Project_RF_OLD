using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.EventSystems;

namespace TechTree
{
    public class TechTree : MonoBehaviour
    {
        [SerializeField]
        private TechTreeSO _techTreeSO;

        private List<TechTreeNode> _techTreeNodes = new List<TechTreeNode>();

        public void SetTechTree(Transform t)
        {
            for (int i = 0; i < _techTreeSO.techTreeNodes.Length; i++)
            {
                var techTreeNode = PoolManager.Instance.Get<TechTreeNode>("Assets/Prefabs/UI/Node/TankNode.prefab", t);

                if (_techTreeSO.techTreeNodes[i] is not null)
                {
                    techTreeNode.SetNode(_techTreeSO.techTreeNodes[i].name);

                    EventTrigger trigger = techTreeNode.GetComponent<EventTrigger>();
                    EventTrigger.Entry entry = new EventTrigger.Entry();

                    entry.eventID = EventTriggerType.PointerClick;

                    entry.callback.AddListener((data) =>
                    {
                        EventManager.TriggerEvent("ChangeModel", _techTreeSO.techTreeNodes[i].transform.GetChild(0).gameObject);
                    });
                }
                else
                {
                    techTreeNode.SetNode("???");
                }

                _techTreeNodes.Add(techTreeNode);
            }
        }

        public void ResetTechTree()
        {
            for (int i = 0; i < _techTreeNodes.Count; i++)
            {
                PoolManager.Instance.Pool("Assets/Prefabs/UI/Node/TankNode.prefab", _techTreeNodes[i].gameObject);
            }

            _techTreeNodes.Clear();
        }
    }
}
