using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Move : MonoBehaviour
{
    [SerializeField]
    private UI.JoyStick _joyStick;

    private float _speed = 5f;

    private void Update()
    {
        if(_joyStick.Direction != Vector2.zero)
        {
            Moving();
        }
    }

    private void Moving()
    {
        Vector3 dir = Vector3.zero;
        dir.x = _joyStick.Horizontal;
        dir.z = _joyStick.Vertical;
        dir = dir * _speed * Time.deltaTime;

        transform.Translate(dir, Space.World);
        transform.rotation = Quaternion.LookRotation(dir.normalized);
    }
}
