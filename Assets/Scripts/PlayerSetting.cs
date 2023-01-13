using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UI;
using Util;

public class PlayerSetting : MonoBehaviour
{
    [Header("Body Parts")]
    [SerializeField]
    private JoyStick _moveJoyStick = null;

    [SerializeField]
    private Bar _hpBar = null;

    [Header("Turret Parts")]
    [SerializeField]
    private JoyStick _attackJoyStick = null;

    [SerializeField]
    private Image _attackImage = null;

    [SerializeField]
    private AttackCancel _attackCancel = null;

    private void Start()
    {
        Tank.Tank tank;
    }
}
