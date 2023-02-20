using SO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UI;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        // TODO: Must change this structure
        public GameObject selectObject;
        public ItemBundleSO Items;
        
        public void ItemShow()
        {
            Time.timeScale = 0;

            for (int i = 0; i < 3; i++)
            {
                var setItem = selectObject.transform.GetChild(i).gameObject;
                SetItem(GetRandomItem(), setItem);
            }
        }
        
        private Item GetRandomItem()
        {
            return Items.items[Random.Range(0, Items.items.Length)];
        }
        
        private void SetItem(Item item, GameObject setItem)
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
                item.AddItem();
                Time.timeScale = 1;
                //TODO: Will change this code
                var temp = CanvasManager.Instance.GetSceneCanvases(1);
                var temp2 = temp as GameSceneCanvases;
                temp2?.ChangeCanvas(0);
            });
            
            e.triggers.Add(entry);
        }
    }
}
