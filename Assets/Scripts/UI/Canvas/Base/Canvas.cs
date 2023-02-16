using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class Canvas : MonoBehaviour
    {
        Canvas _canvas = null;
        
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }
        
        public virtual void EnableCanvas()
        {
            _canvas.enabled = true;
        }
    }
}
