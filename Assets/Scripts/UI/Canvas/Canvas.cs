using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Canvas : MonoBehaviour
    {
        private UnityEngine.Canvas _canvas = null;
    
        private void Awake()
        {
            _canvas = GetComponent<UnityEngine.Canvas>();
        }

        private void Start()
        {
            _canvas.worldCamera ??= Camera.main;
        }
    }
}
