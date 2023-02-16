using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using Cinemachine;

namespace CameraManager
{
    public class CameraManager : Base.CustomGameObject<CameraManager>
    {
        [Header("Cinemachine")]
        [SerializeField]
        private CinemachineVirtualCamera _cmvcam = null;

        public CinemachineVirtualCamera CMvcam => _cmvcam;
        
    }
}
