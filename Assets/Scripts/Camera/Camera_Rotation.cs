using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

namespace CameraSpace
{
    public class Camera_Rotation : MonoBehaviour
    {
        private CinemachineFreeLook _camera;

        private void Awake()
        {
            _camera = GetComponent<CinemachineFreeLook>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
            {
                _camera.m_XAxis.m_InputAxisName = "Mouse X";
                _camera.m_YAxis.m_InputAxisName = "Mouse Y";
            }
            if (Input.GetMouseButtonUp(0))
            {
                _camera.m_XAxis.m_InputAxisName = "";
                _camera.m_YAxis.m_InputAxisName = "";

                _camera.m_XAxis.m_InputAxisValue = 0f;
                _camera.m_YAxis.m_InputAxisValue = 0f;
            }
        }
    }
}
