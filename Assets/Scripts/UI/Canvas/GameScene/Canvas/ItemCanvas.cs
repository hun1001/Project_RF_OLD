using System;
using System.Collections;
using System.Collections.Generic;
//using PlasticPipe.PlasticProtocol.Messages;
using UnityEditor;
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
            UpdateGoldText();
            gameObject.SendMessage("ItemShow");
        }
        
        protected override void SetOnDisableAction()
        {
            
        }

        public void UpdateGoldText()
        {
            _goldText.SetText(PlayerPrefs.GetInt("Gold").ToString());
        }

        public void BackCanvas()
        {
            Time.timeScale = 1f;
            EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
            var temp = CanvasManager.Instance.GetSceneCanvases(1);
            var temp2 = temp as GameSceneCanvases;
            temp2?.ChangeCanvas(0);
        }
    }
}
