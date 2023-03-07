using UnityEngine;

namespace TechTree
{
    [CreateAssetMenu(fileName = "TechTreeSO", menuName = "TechTree/TechTreeSO", order = 1)]
    public class TechTreeSO : ScriptableObject
    {
        public GameObject[] techTreeNodes;
    }
}
