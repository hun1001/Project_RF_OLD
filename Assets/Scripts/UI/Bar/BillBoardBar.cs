using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BillBoardBar : Bar
    {
        protected override void Awake()
        {
            _barImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        private void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
