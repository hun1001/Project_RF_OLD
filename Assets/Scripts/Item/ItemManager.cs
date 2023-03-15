using SO;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using Util;

namespace Item
{
    public class ItemManager : MonoBehaviour
    {
        // TODO: Must change this structure
        [SerializeField]
        private GameObject _selectObject;
        public ItemBundleSO Items;

        private int _itemSelectCnt = 0;

        private WeightPicker<Item> _picker = new WeightPicker<Item>();

        private void Awake()
        {
            int weight = 0;
            foreach (var item in Items.items)
            {
                // y = -x + 6
                weight = -item.itemSO.rarity + 6;
                _picker.Add(item, weight);
            }
        }

        public void ItemShow()
        {
            Time.timeScale = 0;
            _itemSelectCnt = 0;
            for (int i = 0; i < 3; i++)
            {
                var setItem = _selectObject.transform.GetChild(i).gameObject;
                setItem.SetActive(true);
                SetItem(_picker.GetRandomPick(), setItem);
            }
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
                if (PlayerPrefs.GetInt("Gold") < item.itemSO.NecessaryGold)
                {
                    //TODO: ?¬í™” ë¶€ì¡?ì°??„ìš°ê¸?
                    return;
                }
                PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - item.itemSO.NecessaryGold);
                gameObject.SendMessage("UpdateGoldText");

                PoolManager.Instance.Get<Item>(item.gameObject.name, GameObject.Find("Player").transform.GetChild(0)).AddItem();

                setItem.SetActive(false);

                //TODO: Will change this code

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
