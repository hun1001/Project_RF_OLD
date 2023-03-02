using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Tank
{
    public class Skill_Test3 : Tank_Skill
    {
        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            TypeReader.Instance.RicochetAngle *= 2f;
        }
    }
}
