using Util;

namespace Tank
{
    public class Skill_Soviet_Ricochet : Tank_Skill
    {
        public override void Skill()
        {
            if (_currentCooldown > 0f) return;
            base.Skill();

            TypeReader.Instance.RicochetAngle *= 2f;
        }
    }
}
