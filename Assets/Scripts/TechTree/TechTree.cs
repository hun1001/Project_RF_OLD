using Keyword;
using System.Collections.Generic;
using UnityEngine;
using Util;
using UnityEngine.EventSystems;

namespace TechTree
{
    public class TechTree : MonoBehaviour
    {
        [SerializeField]
        private TechTreeSO[] _techTreeSO;

        private List<TechTreeNode> _techTreeNodes = new List<TechTreeNode>();

        private void Awake()
        {
            EventManager.StartListening(EventKeyword.OnSetTechTreeToggle, (object[] t) => SetTechTreeToggle((Transform)t[0], (Transform)t[1]));
            EventManager.StartListening(EventKeyword.OnSetTechTree, (object[] t) => SetTechTree((Transform)t[0], (int)t[1]));
            EventManager.StartListening(EventKeyword.OnResetTechTree, ResetTechTree);
        }

        private void SetTechTree(Transform t, int index)
        {
            ResetTechTree();

            for (int i = 0; i < _techTreeSO[index].techTreeNodes.Length; i++)
            {
                var techTreeNode = PoolManager.Instance.Get<TechTreeNode>("Assets/Prefabs/UI/Node/TankNode.prefab", t);

                if (_techTreeSO[index].techTreeNodes[i] is not null)
                {
                    techTreeNode.SetNode(_techTreeSO[index].techTreeNodes[i].name);

                    if (_techTreeSO[index].techTreeNodes[i].GetComponent<Tank.Tank>() is not null)
                        techTreeNode.SetNodeImage(_techTreeSO[index].techTreeNodes[i].GetComponent<Tank.Tank>().TankSprite);

                    SetNode(i, techTreeNode, index);
                }
                else
                {
                    techTreeNode.SetNode("???");
                }

                _techTreeNodes.Add(techTreeNode);
            }
        }

        private void ResetTechTree()
        {
            for (int i = 0; i < _techTreeNodes.Count; i++)
            {
                PoolManager.Instance.Pool("Assets/Prefabs/UI/Node/TankNode.prefab", _techTreeNodes[i].gameObject);
            }

            _techTreeNodes.Clear();
        }

        private void SetTechTreeToggle(Transform t, Transform nodeT)
        {
            const float offset = 100f;

            for (int i = 0; i < _techTreeSO.Length; i++)
            {
                var techTreeToggle = PoolManager.Instance.Get<TechTreeToggle>("Assets/Prefabs/UI/Toggle/TechTreeCountryToggle.prefab", t);
                var rT = (techTreeToggle.transform as RectTransform);
                rT.offsetMin = new Vector2(rT.offsetMin.x, 0);
                rT.offsetMax = new Vector2(rT.offsetMax.x, 0);
                rT.localScale = Vector3.one;

                rT.localPosition = new Vector3(rT.localPosition.x - (offset * i), rT.localPosition.y, rT.localPosition.z);

                techTreeToggle.SetToggleName(_techTreeSO[i].techTreeName);
                techTreeToggle.SetIcon(_techTreeSO[i].countryFlag);
                techTreeToggle.SetToggleGroup(t.gameObject);
                SetToggle(techTreeToggle, i, nodeT);
            }
        }

        private void SetToggle(TechTreeToggle techTreeToggle, int index, Transform t)
        {
            techTreeToggle.SetToggleEvent((bool isOn) =>
            {
                if (isOn)
                {
                    SetTechTree(t, index);
                }
            });
        }

        private void SetNode(int i, TechTreeNode techTreeNode, int index)
        {
            EventTrigger trigger = techTreeNode.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();

            entry.eventID = EventTriggerType.PointerClick;

            entry.callback.AddListener((data) =>
            {
                EventManager.TriggerEvent("ChangeModel", _techTreeSO[index].techTreeNodes[i].transform.GetChild(0).gameObject);
            });

            trigger.triggers.Add(entry);
        }
    }
}
