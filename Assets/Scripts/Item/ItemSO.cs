using System.Collections;
using System.Collections.Generic;
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

        //����� �������� �̹��� ��������Ʈ
        public Sprite itemSprite;

        //������ ���ſ� �ʿ��� ��ȭ ��
        public int NecessaryGold;
    }
}
