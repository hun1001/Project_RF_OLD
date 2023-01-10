using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

namespace CameraManage
{
    public class Camera_Move : MonoBehaviour
    {
        private JoyStick _joyStick = null;



        private void Update()
        {
            CameraMove();
        }

        private void CameraMove()
        {
            Vector3 moveDir = new Vector3(_joyStick.Direction.x, 0, _joyStick.Direction.y);
            transform.position += moveDir * Time.deltaTime * 10;
        }
    }
}