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

        //사용할 아이템의 이미지 스프라이트
        public Sprite itemSprite;
    }
}
