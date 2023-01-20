using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class Canvas : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<UnityEngine.Canvas>().worldCamera = Camera.main;
        }
    }
}
