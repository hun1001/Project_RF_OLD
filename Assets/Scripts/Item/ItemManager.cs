using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        public GameObject selectObject;
        public Item[] Items;
        
        public void ItemShow()
        {
            selectObject.SetActive(true);
            Time.timeScale = 0;

            for (int i = 0; i < 3; i++)
            {
                var setItem = selectObject.transform.GetChild(i).gameObject;
                SetItem(GetRandomItem(), setItem);
            }
        }
        
        private Item GetRandomItem()
        {
            return Items[Random.Range(0, Items.Length)];
        }
        
        public void SetItem(Item item, GameObject setItem)
        {
            var nameText = setItem.transform.GetChild(0).GetComponent<Text>();
            var descriptionText = setItem.transform.GetChild(1).GetComponent<Text>();

            nameText.text = item.itemSO.itemName;
            descriptionText.text = item.itemSO.description;
            setItem.GetComponent<Image>().sprite = item.itemSO.itemSprite;

            EventTrigger e = setItem.GetComponent<EventTrigger>();
            
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            
            entry.callback.AddListener((data) =>
            {
                Debug.Log($"get Item : {item.itemSO.itemName}");
                item.AddItem();
                Time.timeScale = 1;
                selectObject.SetActive(false);
            });
            
            e.triggers.Add(entry);
        }
    }
}
