using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace TechTree
{
    public class TechTree : MonoBehaviour
    {
        [SerializeField]
        private TechTreeSO _techTreeSO;

        private void SetTechTree(Transform t)
        {
            for (int i = 0; i < _techTreeSO.techTreeNodes.Length; i++)
            {
                if (_techTreeSO.techTreeNodes[i] is not null)
                {
                    var techTreeNode = PoolManager.Instance.Get(_techTreeSO.techTreeNodes[i].gameObject, t);
                }
            }
        }
    }
}
