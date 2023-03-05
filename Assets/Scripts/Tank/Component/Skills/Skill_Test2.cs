using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Skill_Test2 : Tank_Skill
    {
        [Header("Other")]
        [Range(0f, 100f)]
        [SerializeField]
        private float _armour = 90f;

        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            SendMessage("SetArmour", _armour);
        }

        protected override void Restoration()
        {
            SendMessage("SetArmour", 0f);
        }
    }
}
