using UnityEngine;
using UnityEngine.UI;
using Keyword;

namespace UI
{
    public class ItemCanvas : BaseCanvas
    {
        [SerializeField]
        private Button _backButton = null;

        [SerializeField]
        private TextController _goldText = null;
        public TextController GoldText => _goldText;

        protected override void Awake()
        {
            base.Awake();
            _backButton.onClick.AddListener(BackCanvas);
            //EventManager.StartListening(EventKeyword.OnUpdateGold, (gold) =>
            //{
            //    _goldText.SetText(gold[0].ToString());
            //});
        }

        protected override void SetOnEnableAction()
        {
            Time.timeScale = 0f;
            EventManager.TriggerEvent(EventKeyword.OnItemCanvasOpen);
            UpdateGoldText();
            gameObject.SendMessage("ItemShow");
        }

        protected override void SetOnDisableAction()
        {
            Time.timeScale = 1f;
            EventManager.TriggerEvent(EventKeyword.OnItemCanvasClose);
        }

        public void UpdateGoldText()
        {
            _goldText.SetText(PlayerPrefs.GetInt("Gold").ToString());
        }

        public void BackCanvas()
        {
            Time.timeScale = 1f;
            EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
            FindObjectOfType<GameSceneCanvases>().ChangeCanvas(CanvasChangeType.PlayGame);
        }
    }
}
