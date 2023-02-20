using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/DataBundle/ItemBundle")]
    public class ItemBundleSO : ScriptableObject
    {
        public Item.Item[] items;
    }
}
