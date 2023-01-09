using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Rotate : MonoBehaviour
{
    [SerializeField]
    private UI.JoyStick _joyStick;

    private float _rotateSpeed = 5f;

    private void Update()
    {
        if(_joyStick.Direction != Vector2.zero)
        {
            TurretRotation();
        }
    }

    private void TurretRotation()
    {
        Vector3 dir = Vector3.zero;
        dir.x = _joyStick.Horizontal;
        dir.z = _joyStick.Vertical;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir.normalized), _rotateSpeed * Time.deltaTime);
    }
}
