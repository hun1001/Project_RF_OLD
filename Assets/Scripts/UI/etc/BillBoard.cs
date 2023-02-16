using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class BillBoard : MonoBehaviour
    {
        private Transform _cameraTransform = null;

        private void Awake()
        {
            if (Camera.main)
            {
                _cameraTransform = Camera.main.transform;
                if (!_cameraTransform)
                {
                    Debug.LogError("Camera.main.transform is null");
                }
            }
        }

        private void LateUpdate()
        {
            Quaternion rotation = _cameraTransform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
    }
}
