using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyword;

namespace Tank
{
    public class Skill_Test1 : Tank_Skill
    {
        [SerializeField]
        private float _radius = 0f;

        private int layerMask = 0;

        protected override void Awake()
        {
            base.Awake();
            layerMask = 1 << LayerMask.NameToLayer("Tank");
        }



        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, layerMask);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + (colliders.Length - 1));
            EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
        }
    }
}
