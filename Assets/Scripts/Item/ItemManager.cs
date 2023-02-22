using SO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UI;
using Keyword;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        // TODO: Must change this structure
        public GameObject selectObject;
        public ItemBundleSO Items;

        private int _itemSelectCnt = 0;

        public void ItemShow()
        {
            Time.timeScale = 0;
            _itemSelectCnt = 0;
            for (int i = 0; i < 3; i++)
            {
                var setItem = selectObject.transform.GetChild(i).gameObject;
                setItem.SetActive(true);
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
            var goldText = setItem.transform.GetChild(2).GetComponent<Text>();

            nameText.text = item.itemSO.itemName;
            descriptionText.text = item.itemSO.description;
            goldText.text = item.itemSO.NecessaryGold.ToString();
            setItem.GetComponent<Image>().sprite = item.itemSO.itemSprite;

            EventTrigger e = setItem.GetComponent<EventTrigger>();
            
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            
            entry.callback.AddListener((data) =>
            {
                if(PlayerPrefs.GetInt("Gold") < item.itemSO.NecessaryGold)
                {
                    //TODO: 재화 부족 창 띄우기
                    return;
                }
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - item.itemSO.NecessaryGold);
                gameObject.SendMessage("UpdateGoldText");
                item.AddItem();
                setItem.SetActive(false);

                //TODO: Will change this code

                //var temp = CanvasManager.Instance.GetSceneCanvases(1);
                //var temp2 = temp as GameSceneCanvases;
                //temp2?.ChangeCanvas(0);
                if (_itemSelectCnt++ > 1)
                {
                    gameObject.SendMessage("BackCanvas");
                }
            });

            e.triggers.Clear();
            e.triggers.Add(entry);
        }
    }
}
