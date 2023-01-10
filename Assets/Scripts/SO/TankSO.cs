using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Data/Tank")]
public class TankSO : ScriptableObject
{
    [Header("Tank's Hp")]
    [Range(0f, 10000f)]
    public float hp;
    [Header("Tank's Speed")]
    [Range(0f, 10f)]
    public float speed;
    [Header("Tank's Reload Speed")]
    [Range(0f, 20f)]
    public float reloadSpeed;
}
