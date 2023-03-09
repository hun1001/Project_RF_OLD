using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(menuName = "SO/Data/Tank")]
    public class TankSO : ScriptableObject
    {
        public Sprite tankSprite;

        [Header("Hp")]
        public float hp;

        [Header("MaxSpeed")]
        public float maxSpeed;

        [Header("Rotation Speed")]
        public float rotationSpeed;

        [Header("Mass")]
        public float mass;

        [Header("Acceleration")]
        public float acceleration;

        [Header("Armour")]
        public float armour;

        [Header("Load")]
        public float load;
    }
}
