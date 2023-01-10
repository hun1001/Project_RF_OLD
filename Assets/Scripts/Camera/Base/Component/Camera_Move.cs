using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace CameraManage
{
    public class Camera_Move : CameraComponent
    {
        private JoyStick _joyStick = null;

        private void Awake()
        {
            _joyStick = Instance.JoyStick;
        }

        private void Update()
        {
            CameraMove();
        }

        private void CameraMove()
        {
            Vector3 moveDir = new Vector3(_joyStick.Direction.x, 0, _joyStick.Direction.y);

            Debug.Log(moveDir);

            transform.position += moveDir * Time.deltaTime * 10;
        }
    }
}