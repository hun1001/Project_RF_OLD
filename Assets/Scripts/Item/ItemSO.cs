using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Item")]
    public class ItemSO : ScriptableObject
    {
        public string itemID;

        public string itemName;

        public int rarity;

        public string description;

        //사용할 아이템의 이미지 스프라이트
        public Sprite itemSprite;

        //아이템 구매에 필요한 재화 양
        public int NecessaryGold;
    }
}
