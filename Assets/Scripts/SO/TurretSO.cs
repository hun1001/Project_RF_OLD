using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Turret")]
public class TurretSO : ScriptableObject
{
    [Header("Rotation Speed")]
    [Range(0f, 40f)]
    public float rotationSpeed;
}
