using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Item")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        
        public int rarity;
        
        public string description;
    }
}
