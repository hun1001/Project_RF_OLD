using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Keyword;

namespace Tank
{
    public class Skill_Soviet_Seizure : Tank_Skill
    {
        [Header("Other")]
        [SerializeField]
        private float _radius = 10f;

        private int _layerMask = 0;

        protected override void Awake()
        {
            base.Awake();
            _layerMask = 1 << LayerMask.NameToLayer("Tank");
        }



        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            Collider[] colliders = Physics.OverlapSphere(transform.position, _radius, _layerMask);
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + (colliders.Length - 1));
            EventManager.TriggerEvent(EventKeyword.OnUpdateGold, PlayerPrefs.GetInt("Gold"));
        }
    }
}
