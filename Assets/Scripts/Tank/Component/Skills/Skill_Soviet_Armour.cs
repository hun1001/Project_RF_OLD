using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Skill_Soviet_Armour : Tank_Skill
    {
        [Header("Other")]
        [Range(0f, 100f)]
        [SerializeField]
        private float _armour = 90f;

        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            ChangeLayer("AmourTank", transform);

            SendMessage("SetArmour", _armour);
        }

        private void ChangeLayer(string layerName, Transform objTransform)
        {
            foreach (Transform t in objTransform)
            {
                t.gameObject.layer = LayerMask.NameToLayer(layerName);
                if (t.childCount > 0)
                    ChangeLayer(layerName, t);
            }
        }

        protected override void Restoration()
        {
            float dummy = 0f;

            ChangeLayer("Default", transform);

            SendMessage("SetArmour", dummy);
        }
    }
}
